using Microsoft.EntityFrameworkCore;
using ShagunMarriage.Repository;
using ShagunMarriage.Services;

namespace ShagunMarriage
{
    public static class RegisterServices
    {

        public static void Register(IServiceCollection services)
        {
            RegisterServicesInContainer(services);

            RegisterRepositoryInContainer(services);
        }

        private static void RegisterRepositoryInContainer(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        private static void RegisterServicesInContainer(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
