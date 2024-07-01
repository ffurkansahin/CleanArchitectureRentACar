
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Behaviors;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Authentication;
using CleanArchitecture.Infrastructure.Services;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Persistence.Repositories;
using CleanArchitecture.Persistence.Service;
using CleanArchitecture.WebApi.Middleware;
using GenericRepository;
using MediatR;

namespace CleanArchitecture.WebApi.Configuration;

public sealed class PersistenceDIServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ErrorMiddleware>();

        services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IMailService, MailService>();

        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<ICarService, CarService>();
    }
}
