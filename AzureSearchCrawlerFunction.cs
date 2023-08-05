using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;


///
namespace Teamruegg.AzureSearchCrawler
{
    public class AzureSearchCrawlerFunction
    {
        private readonly ILogger _logger;

        public AzureSearchCrawlerFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AzureSearchCrawlerFunction>();
        }

        [Function("AzureSearchCrawlerFunction")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
