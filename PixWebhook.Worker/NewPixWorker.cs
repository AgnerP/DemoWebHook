using Microsoft.Azure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rebus.Activation;
using Rebus.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PixWebhook.Worker
{
    public class NewPixWorker : BackgroundService
    {
        private readonly IConfiguration _config;

        public NewPixWorker(IConfiguration config)
        {
            _config = config;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var storageAccount = CloudStorageAccount.Parse(
                _config["AzureQueues:ConnectionString"]);

            using var activator = new BuiltinHandlerActivator();
            activator.Register(() => new NewPixHandler());
            Configure.With(activator)
                .Transport(t => t.UseAzureStorageQueues(
                    storageAccount, _config["AzureQueues:QueueName"]))
                .Start();

            await Task.Delay(Timeout.InfiniteTimeSpan, stoppingToken);
        }
    }
}
