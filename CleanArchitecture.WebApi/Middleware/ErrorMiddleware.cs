
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Persistence.Context;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.WebApi.Middleware
{
    public sealed class ErrorMiddleware : IMiddleware
    {
        private readonly AppDbContext _appDbContext;

        public ErrorMiddleware(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (Exception ex)
            {
                await LogExceptionToDatabaseAsync(ex, context.Request);
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            if (ex.GetType() == typeof(ValidationException))
            {
                return context.Response.WriteAsync(new ValidationErrorDetail
                {
                    Errors = ((ValidationException)ex).Errors.Select(i => i.PropertyName),
                    StatusCode = 403
                }.ToString());
            }
            return context.Response.WriteAsync(new ErrorResult
            {
                Message = ex.Message,
                StatusCode = context.Response.StatusCode
            }.ToString());
        }

        private async Task LogExceptionToDatabaseAsync(Exception ex, HttpRequest request)
        {
            ErrorLog errorLog = new()
            {
                ErrorMessage = ex.Message,
                StackTrace = ex.StackTrace,
                RequestPath = request.Path,
                RequestMethod = request.Method,
                TimeStamp = DateTime.Now,
            };
            await _appDbContext.Set<ErrorLog>().AddAsync(errorLog, default);
            await _appDbContext.SaveChangesAsync(default);
        }
    }
}
