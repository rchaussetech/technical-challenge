using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Technical.Challenge.Api;

namespace Technical.Challenge.Tests.Abstracts
{
    public abstract class XUnitBaseTest
    {
        private TestServer _testSerser;

        protected TestServer TestServer
        {
            get
            {
                if (_testSerser == null)
                {
                    IConfigurationRoot configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .AddEnvironmentVariables()
                        .Build();

                    IWebHostBuilder builder = new WebHostBuilder()
                        .UseConfiguration(configuration)
                        .UseStartup<StartupTest>();

                    _testSerser = new TestServer(builder);
                }

                return _testSerser;
            }
        }

        protected async Task<string> PostAsync(string requestUri, string requestJson)
        {
            StringContent requestContent = new(requestJson, Encoding.UTF8, "application/json");
            return await PostAsync(requestUri, requestContent);
        }

        protected async Task<string> PostAsync(string requestUri, HttpContent requestContent)
        {
            string responseContent = string.Empty;
            using (HttpClient client = TestServer.CreateClient())
            {
                HttpResponseMessage response = await client.PostAsync(requestUri, requestContent);
                responseContent = await response.Content.ReadAsStringAsync();
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(responseContent);
                }
            }
            return responseContent;
        }
    }
}
