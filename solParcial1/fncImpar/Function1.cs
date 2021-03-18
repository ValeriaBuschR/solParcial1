using System;
using fncImpar.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace fncImpar
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async System.Threading.Tasks.Task RunAsync([ServiceBusTrigger("qImpar", Connection = "MyConn")] string myQueueItem,
            [CosmosDB(
            databaseName: "dbsolparcial",
            collectionName: "impar",
            ConnectionStringSetting = "MiBase"
            )]IAsyncCollector<object> datos,
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            var data = JsonConvert.DeserializeObject<Random1>(myQueueItem);
            await datos.AddAsync(data);

        }
    }
}
