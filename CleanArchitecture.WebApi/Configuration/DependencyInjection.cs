using System.Reflection;

namespace CleanArchitecture.WebApi.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection InstallServices(this IServiceCollection services, IConfiguration configuration,IHostBuilder hostBuilder, params Assembly[] assemblies)
        {
            IEnumerable<IServiceInstaller> serviceInstallers = assemblies
                .SelectMany(i=>i.DefinedTypes)
                .Where(IsAssignableToType<IServiceInstaller>)
                .Select(Activator.CreateInstance)
                .Cast<IServiceInstaller>();
            foreach(IServiceInstaller service in serviceInstallers)
            {
                service.Install(services, configuration,hostBuilder);
            }  
            return services;

            static bool IsAssignableToType<T>(TypeInfo typeInfo)
            {
                return typeof(T).IsAssignableFrom(typeInfo) &&
                    !typeInfo.IsInterface&&
                    !typeInfo.IsAbstract;
            }
        }
    }
}
