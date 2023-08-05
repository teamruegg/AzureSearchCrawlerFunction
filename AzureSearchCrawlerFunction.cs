using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Teamruegg.AzureSearchCrawler
{

    public class MultiResponse
    {
        [QueueOutput("outqueue",Connection = "AzureWebJobsStorage")]
        public string[] Messages { get; set; }
        public HttpResponseData HttpResponse { get; set; }
    }

    public class AzureSearchCrawlerFunction
    {
        private readonly ILogger _logger;

        public AzureSearchCrawlerFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AzureSearchCrawlerFunction>();
        }

        [Function("AzureSearchCrawlerFunction")]
        //ori: public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
         public MultiResponse Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req, FunctionContext executionContext)
        {
    
            var logger = executionContext.GetLogger("HttpExample");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var message = "Welcome to Azure Functions!";

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString(message);

            // Return a response to both HTTP trigger and storage output binding.
            return new MultiResponse()
            {
                // Write a single message.
                Messages = new string[] { message },
                HttpResponse = response
            };
        }
    }
}
