using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Infastructure.Authentication;
using BuberDinner.Infastructure.Services;
using BuberDinner.Application.Common.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using BuberDinner.Infastructure.Persistence;
using BuberDinner.Application.Common.Interfaces.Persistence;

namespace BuberDinner.Infastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfastructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}