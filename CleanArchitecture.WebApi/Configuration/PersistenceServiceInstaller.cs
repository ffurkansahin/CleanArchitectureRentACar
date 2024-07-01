
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.WebApi.Configuration
{
    public class PersistenceServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            string conString = configuration.GetConnectionString("SqlServer");

            services.AddAutoMapper(typeof(CleanArchitecture.Persistence.AssemblyReference).Assembly);
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(conString));
            services.AddIdentity<AppUser, Role>().AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
