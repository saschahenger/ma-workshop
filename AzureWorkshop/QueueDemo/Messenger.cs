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

        public Messenger(string account)
        {
            _account = account;
        }

        public async Task Start()
        {
            Console.WriteLine($"MESSENGER DEMO ({_account})");
            await Task.WhenAny(Receive(), Send());
        }

        private async Task Receive()
        {
            // todo: eigene Queue ermitteln
            await EnsureQueueExists(_account);

            while (true)
            {
                // todo: Nachricht aus Queue laden
                // todo: Nachricht ermitteln und ausgeben

                Message message = null;
                if(message!= null)
                    Console.WriteLine($"{message.Date.ToShortTimeString()} - from {message.From}: {message.Content}");

                await Task.Delay(1000);
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

                // todo: Empfänger Queue ermitteln
                await EnsureQueueExists(arguments[0]);

                // todo: Nachricht verschicken
            }
        }

        private async Task EnsureQueueExists(string account)
        {
            // todo: gegebenenfalls Queue erstellen und zurückgeben
        }
    }
}
