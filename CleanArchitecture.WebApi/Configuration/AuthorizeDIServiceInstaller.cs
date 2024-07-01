
namespace CleanArchitecture.WebApi.Configuration
{
    public class AuthorizeDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder hostBuilder)
        {
            services.AddAuthentication().AddJwtBearer();
            services.AddAuthorization();
        }
    }
}
