using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace AzureStaticWebApps.Blazor.Authentication
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