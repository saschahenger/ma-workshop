using System;
using System.Collections.Generic;
using System.Text;

namespace AzureWorkshop
{
    class Settings
    {
        // todo: mit gültigem ConnectionString aus dem Portal ersetzen
        // siehe: https://docs.microsoft.com/en-us/azure/storage/common/storage-create-storage-account#manage-your-storage-access-keys
        public static string AzureConnectionString => "DefaultEndpointsProtocol=https;AccountName=<account>;AccountKey=<key>;EndpointSuffix=core.windows.net";

        public static bool AskFor(string question)
        {
            Console.WriteLine($"{question} (y/n)");
            return Console.ReadKey().Key == ConsoleKey.Y;
        }
    }
}
