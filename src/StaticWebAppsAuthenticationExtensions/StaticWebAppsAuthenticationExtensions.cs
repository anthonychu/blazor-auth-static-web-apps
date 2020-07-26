using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace StaticWebAppsAuthentication
{
    public static class StaticWebAppsAuthenticationExtensions
    {
        public static IServiceCollection AddStaticWebAppsAuthentication(this IServiceCollection services)
        {
            return services
                .AddAuthorizationCore()
                .AddScoped<AuthenticationStateProvider, StaticWebAppsAuthenticationStateProvider>();
        }
    }
}