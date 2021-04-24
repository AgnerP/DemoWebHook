using Azure.Storage.Queues;
using Microsoft.Azure.Storage;
using PixWebhook.Messages;
using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PixWebhook.Worker
{
    public class NewPixHandler : IHandleMessages<PixMessage>
    {
        private readonly QueueClient queueClient;

        public NewPixHandler(QueueClient queueClient)
        {
            this.queueClient = queueClient;
        }

        public Task Handle(PixMessage message)
        {
            Console.WriteLine($"Pix recebido: {message.Body}.");

            // Create the queue if it doesn't already exist
            queueClient.CreateIfNotExists();

            if (queueClient.Exists())
            {
                // Send a message to the queue
                queueClient.SendMessage($"Converted Pix Message saved: {Guid.NewGuid().ToString()}");
            }

            Console.WriteLine($"Inserted: {message}");

            return Task.CompletedTask;
        }
    }
}
