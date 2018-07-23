using AzureWorkshop.QueueDemo;
using System;
using System.Threading.Tasks;
using AzureWorkshop.BlobDemo;

namespace AzureWorkshop
{
    internal class Program
    {
        private static void Main(string[] args) => MainAsync(args).GetAwaiter().GetResult();

        //  Main Methode in .Net Core akzeptiert noch kein async
        private static async Task MainAsync(string[] args)
        {
            Console.WriteLine("AZURE WORKSHOP");

            var waitingForCommand = true;
            while (waitingForCommand)
            {
                // Demo auswählen
                var arguments = (Console.ReadLine() ?? string.Empty)
                    .ToLower()
                    .Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

                if (arguments.Length == 0)
                    arguments = new[] {string.Empty};

                // Demo starten
                switch (arguments[0])
                {
                    case "messenger":
                        var messenger = new Messenger(account: arguments.Length > 1 ? arguments[1] : "anonym");
                        await messenger.Start();
                        waitingForCommand = false;
                        break;

                    case "dropbox":
                        var dropBox = new DropBox(
                            account: arguments.Length > 1 ? arguments[1] : "anonym", 
                            folder: arguments.Length > 2 ? arguments[2] : @"d:\ma-workshop\dropbox\");
                        await dropBox.StartAsync();
                        return;

                    case "elastic":
                        return;

                    case "exit":
                        waitingForCommand = false;
                        break;

                    default:
                        Console.WriteLine("Usage: messenger <account> | dropbox <account> <folder>| elastic | exit");
                        break;
                }
            }

            Console.WriteLine("Ciao");
            Console.ReadLine();
        }
    }
}
