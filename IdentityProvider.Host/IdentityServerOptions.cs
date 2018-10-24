using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProvider.Host
{
    internal class IdentityServerOptions
    {
        // Set default value.
        public IdentityServerOptions()
        {
            this.ExternalAuthentication = new ExternalAuthentication()
            {
                IsEnabled = false,
            };
        }

        public ExternalAuthentication ExternalAuthentication { get; set; }

        public Certificate SigningCertificate { get; set; }

        public Dictionary<string, Endpoint> Endpoints { get; } = new Dictionary<string, Endpoint>();

        public List<Client> Clients { get; } = new List<Client>();

        public List<ApiResource> ApiResources { get; } = new List<ApiResource>();

        public Dictionary<string, string> ClientSecretMap { get; set; }
    }

    internal class Endpoint
    {
        public bool IsEnabled { get; set; }

        public string Address { get; set; }

        public int Port { get; set; }

        public Certificate Certificate { get; set; }
    }

    internal class Certificate
    {
        public string Source { get; set; }

        public string Path { get; set; }

        public string Password { get; set; }

        public string ThumbPrint { get; set; }
    }

    internal class ExternalAuthentication
    {
        public bool IsEnabled { get; set; }

        public string AuthorityServer { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}