using System;
using fncPar.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace fncPar
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async System.Threading.Tasks.Task RunAsync([ServiceBusTrigger("qPar", Connection = "MyConn")]string myQueueItem,
            [CosmosDB(
            databaseName: "dbsolparcial",
            collectionName: "par",
            ConnectionStringSetting = "AccountEndpoint=https://dbparimpar.documents.azure.com:443/;AccountKey=X71vVHrBswtKHCzIUFzXv6pq90EQ1WD24fdpqI7yK3NwTAZYEM7xg3Y9MtjaPJWjF4TEIcrJNAmpZ2IOx0l2fw==;"
            )]IAsyncCollector<object> datos,
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            var data = JsonConvert.DeserializeObject<Random1>(myQueueItem);
            await datos.AddAsync(data);

        }
    }
}
