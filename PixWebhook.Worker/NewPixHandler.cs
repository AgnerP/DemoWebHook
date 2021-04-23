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
        public Task Handle(PixMessage message)
        {
            Console.WriteLine($"Pix recebido: {message.Body}.");
            return Task.CompletedTask;
        }
    }
}
