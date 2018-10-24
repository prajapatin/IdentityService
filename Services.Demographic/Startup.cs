using System.Web.Http;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Services.Demographic.Startup))]

namespace Services.Demographic
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                ValidationMode = ValidationMode.Both,
                Authority = "http://localhost:54191",
                RequiredScopes = new string[] { "PatientAPI:write" }
                
            });

            // configure web api
            var config = new HttpConfiguration();
           
            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
            );

            // require authentication for all controllers
            config.Filters.Add(new AuthorizeAttribute());

            app.UseWebApi(config);

        }
    }
}
