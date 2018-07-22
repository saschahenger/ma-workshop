using System;
using System.Collections.Generic;
using System.Text;

namespace AzureWorkshop
{
    class Settings
    {
        // http://<storage account>.queue.core.windows.net/<queue> 
        // todo: mit gültigem ConnectionString aus dem Portal ersetzen
        // siehe: https://docs.microsoft.com/en-us/azure/storage/common/storage-create-storage-account#manage-your-storage-access-keys
        //public static string AzureConnectionString => "DefaultEndpointsProtocol=https;AccountName=<account>;AccountKey=<key>;EndpointSuffix=core.windows.net";
        public static string AzureConnectionString = "DefaultEndpointsProtocol=https;AccountName=saschahengerstorage01;AccountKey=nyCPT7eCFCW4f/V/QQvpD0rKKUMV3HfhWQNtRfhBdGjyVOB+5zKnaHbneWQ5HEC1F7fxDoBicMKLAkixRruhqA==;EndpointSuffix=core.windows.net";

        public static bool AskFor(string question)
        {
            Console.WriteLine($"{question} (y/n)");
            return Console.ReadKey().Key == ConsoleKey.Y;
        }
    }
}
