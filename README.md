# Blazor Authentication Extension for Azure Static Web Apps

Use Azure Static Web Apps authentication in Blazor WebAssembly apps.

## Usage

### Install NuGet package

```bash
dotnet add package AnthonyChu.AzureStaticWebApps.Blazor.Authentication --version 0.0.1-preview
```

### Update Program.cs

Add `using AzureStaticWebApps.Blazor.Authentication` and register services with `AddStaticWebAppsAuthentication()`.

```csharp
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using AzureStaticWebApps.Blazor.Authentication;

namespace BlazorLogin
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services
                .AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
                .AddStaticWebAppsAuthentication();
            await builder.Build().RunAsync();
        }
    }
}
```

### Update App.razor

Add `<CascadingAuthenticationState>` and `<AuthorizeRouteView>` to App.razor. For more information, check out the [Blazor security docs](https://docs.microsoft.com/en-us/aspnet/core/blazor/security/?view=aspnetcore-3.1#customize-unauthorized-content-with-the-router-component).

```html
<CascadingAuthenticationState>
    <Router AppAssembly="@typeof(Program).Assembly">
        <Found Context="routeData">
            <AuthorizeRouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
        </Found>
        <NotFound>
                <LayoutView Layout="@typeof(MainLayout)">
                    <p>Sorry, there's nothing at this address.</p>
                </LayoutView>
        </NotFound>
    </Router>
</CascadingAuthenticationState>
```

### Log user into Azure Static Web Apps using social

Redirect the user to `/.auth/login/<social-provider>` to log them in. More info at the [Static Web Apps authentication docs](https://docs.microsoft.com/en-us/azure/static-web-apps/authentication-authorization).

### Access user identity

Use `context.User` to get information about the user.

```html
<AuthorizeView>
    <Authorized>
        Hello, @context.User.Identity.Name!
        <a href="/.auth/logout?post_logout_redirect_uri=/">Log out</a>
    </Authorized>
    <NotAuthorized>
        <a href="/login-providers">Log in</a>
    </NotAuthorized>
</AuthorizeView>
```

## Configuration

By default, the auth provider will call `/.auth/me` to determine if a user is logged in and get information about the logged in user. Configure `StaticWebAppsAuthentication:AuthenticationDataUrl` in appsettings.json (or an envionrment specific version) to use a different endpoint.

For instance, in local development you can use a static file:

```json
{
  "StaticWebAppsAuthentication": {
    "AuthenticationDataUrl": "/sample-data/me.json"
  }
}
```

See [sample-data/me.json](sample/app/sample-data/me.json) for an example of the structure. For more information, check out the [Static Web Apps docs](https://docs.microsoft.com/en-us/azure/static-web-apps/user-information).

## Sample app

Check out the sample app at [sample/app](sample/app).

---

This is not an officially supported Microsoft project.