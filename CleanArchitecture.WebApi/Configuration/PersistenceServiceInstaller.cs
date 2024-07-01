
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CleanArchitecture.WebApi.Configuration
{
    public class PersistenceServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder hostBuilder)
        {
            string conString = configuration.GetConnectionString("SqlServer");

            services.AddAutoMapper(typeof(CleanArchitecture.Persistence.AssemblyReference).Assembly);
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(conString));
            services.AddIdentity<AppUser, Role>().AddEntityFrameworkStores<AppDbContext>();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.MSSqlServer(conString, tableName: "Logs", autoCreateSqlTable: true)
                .CreateLogger();
            hostBuilder.UseSerilog();
        }
    }
}
