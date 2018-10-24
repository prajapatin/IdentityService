using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvider.Common
{
    public class Config

    {
        // scopes define the API resources in your system
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("PatientAPI", "Patient Demographic API")
            };

        }


        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {

            // client credentials client
            return new List<Client>
            {
                new Client
                {

                    ClientId = "IdentityProvider.Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "PatientAPI" }

                }
            };
        }
    }
}
