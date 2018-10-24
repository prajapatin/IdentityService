using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProvider.Host
{
    internal static class IdentityServerExtensions
    {
        private static readonly IdentityResource[] IdentityResources = new IdentityResource[] { new IdentityResources.OpenId(), new IdentityResources.Profile() };

        public static IIdentityServerBuilder AddConfiguredResources(this IIdentityServerBuilder builder, IConfiguration configuration)
        {
            var settings = configuration.GetSection("IdentityServerOptions").Get<IdentityServerOptions>();

            builder.AddInMemoryIdentityResources(IdentityResources)
                .AddInMemoryApiResources(settings.ApiResources)
                .AddInMemoryClients(settings.Clients);

            return builder;
        }
    }
}
