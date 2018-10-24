using IdentityModel;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvider.Client
{
    class Program
    {
        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            // discover endpoints from metadata
            var disco = await DiscoveryClient.GetAsync("http://localhost:54191");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }
            // request token
            //"secret"
            var tokenClient = new TokenClient(disco.TokenEndpoint, "IdentityProvider.Client", "secret", new HttpClientHandler { ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => errors == SslPolicyErrors.None || errors == SslPolicyErrors.RemoteCertificateNameMismatch });
            var tokenResponse = Task.Run(() => tokenClient.RequestClientCredentialsAsync("PatientAPI:write")).Result;

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }
            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");

            // call api
            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync("http://localhost:54192/api/patient");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }
            Console.ReadLine();
        }
    }
}
