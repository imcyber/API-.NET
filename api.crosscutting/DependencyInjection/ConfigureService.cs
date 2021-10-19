using api.domain.Interfaces.Services.User;
using api.service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace api.crosscutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
        }
    }
}
