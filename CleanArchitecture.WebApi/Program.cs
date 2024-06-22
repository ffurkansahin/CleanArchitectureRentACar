using CleanArchitecture.Application.Services;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Persistence.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers()
    .AddApplicationPart(typeof(CleanArchitecture.Presentation.AssemblyReference).Assembly);

string conString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddScoped<ICarService, CarService>();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(conString));

builder.Services.AddMediatR(cfr => 
cfr.RegisterServicesFromAssembly(typeof
(CleanArchitecture.Application.AssemblyReference).Assembly));

builder.Services.AddAutoMapper(typeof(CleanArchitecture.Persistence.AssemblyReference).Assembly);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
