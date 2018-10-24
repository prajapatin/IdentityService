using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

[assembly: OwinStartup(typeof(IdentityProvider.API.Startup))]

namespace IdentityProvider.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            
            app.UseCookieAuthentication(new CookieAuthenticationOptions { });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                AuthenticationType = "oidc",
                SignInAsAuthenticationType = "Cookies",
                Authority = "http://localhost:5000/",
                RedirectUri = "http://localhost:44301/signin-oidc",
                PostLogoutRedirectUri = "http://localhost:44301/signout-callback-oidc",
                ClientId = "IdentityProvider.Client",
                ClientSecret = "K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=",
                ResponseType = "id_token",
                Scope = "openid profile",
                
                UseTokenLifetime = false,
                RequireHttpsMetadata = false,
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    SecurityTokenValidated = (context) =>
                    {
                        var identity = context.AuthenticationTicket.Identity;
                        var name = identity.Claims.FirstOrDefault(c => c.Type == identity.NameClaimType)?.Value;

                        return Task.FromResult(0);
                    }
                }
            });

        }
    }
}
