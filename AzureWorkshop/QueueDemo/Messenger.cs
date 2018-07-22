using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AzureWorkshop.QueueDemo
{
    /*
     * Todo:  Ein Messenger auf Basis von Queues
     *        Jeder Account hat eine Queue, von der seine Nachrichten abgerufen werden
     *        Nachrichten an andere Accounts werden in deren Queues geschrieben
     *
     * HowTo: https://docs.microsoft.com/en-gb/azure/storage/queues/storage-dotnet-how-to-use-queues
     * NuGet: WindowsAzure.Storage, Newtonsoft.JSON
     */

    internal class Messenger
    {
        private readonly string _account;
        private readonly CloudQueueClient _client;

        public Messenger(string account)
        {
            _account = account;
            _client = CloudStorageAccount.Parse(Settings.AzureConnectionString).CreateCloudQueueClient();
        }

        public async Task Start()
        {
            Console.WriteLine($"MESSENGER DEMO ({_account})");
            await Task.WhenAny(Receive(), Send());
        }

        private async Task Receive()
        {
            // eigene Queue
            var queue = await EnsureQueueExists(_account);

            while (true)
            {
                // Nachricht laden
                var cloudMessage = await queue.GetMessageAsync();
                if (cloudMessage == null)
                {
                    await Task.Delay(1000);
                    continue;
                }
                await queue.DeleteMessageAsync(cloudMessage);

                // Nachricht ausgeben
                var message = JsonConvert.DeserializeObject<Message>(cloudMessage.AsString);
                Console.WriteLine($"{message.Date.ToShortTimeString()} - from {message.From}: {message.Content}");
            }
        }

        private async Task Send()
        {
            while (true)
            {
                // Nachricht einlesen
                var arguments = (Console.ReadLine() ?? string.Empty)
                    .ToLower()
                    .Split((char[])null, 2, StringSplitOptions.RemoveEmptyEntries);

                if(arguments.Length > 0 && arguments[0] == "exit")
                    return;

                if(arguments.Length != 2)
                    continue;

                // Empfänger Queue
                var queueReference = await EnsureQueueExists(arguments[0]);

                // Nachricht verschicken
                await queueReference.AddMessageAsync(
                    new CloudQueueMessage(JsonConvert.SerializeObject(new Message
                    {
                        From = _account,
                        To = arguments[0],
                        Content = arguments[1],
                        Date = DateTime.Now
                    })));
            }
        }

        private async Task<CloudQueue> EnsureQueueExists(string account)
        {
            var queue = _client.GetQueueReference(account);
            await queue.CreateIfNotExistsAsync();
            return queue;
        }
    }
}
