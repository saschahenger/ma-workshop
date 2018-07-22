using AzureWorkshop.QueueDemo;
using System;
using System.Threading.Tasks;

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
                // Demo einlesen
                var arguments = (Console.ReadLine() ?? string.Empty)
                    .ToLower()
                    .Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

                if (arguments.Length == 0)
                    arguments = new[] {string.Empty};

                arguments[0] = "messenger";

                // Demo starten
                switch (arguments[0])
                {
                    case "messenger":
                        var messenger = new Messenger(account: arguments.Length > 1 ? arguments[1] : "henger");
                        await messenger.Start();
                        waitingForCommand = false;
                        break;

                    case "dropbox":
                        //var dropBox = new DropBox(account: "henger", folder: @"d:\ma-workshop\dropbox\");
                        //dropBox.Start();
                        return;

                    case "elastic":
                        return;

                    case "exit":
                        waitingForCommand = false;
                        break;

                    default:
                        Console.WriteLine("Usage: messenger <accountName> | dropbox <accountName> | elastic | exit");
                        break;
                }
            }

            Console.WriteLine("Ciao");
            Console.ReadLine();
        }
    }
}
