using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AzureWorkshop.BlobDemo
{
    /*
     * Todo:  DropBox Klon, der Dateien zwischen Cloud und einem lokalem Verzeichnis kopiert
     *        alle Dateien aus dem lokalen Verzeichnis sollen auch in der Cloud existieren
     *        alle Dateien aus der Cloud sollen auch im Verzeichnis (account) existieren
     *        das Löschen und Synchronisieren von gelöschten Dateien unterstützen wir nicht
     *        ... oder wenn sich Dateien geändert haben etc.
     *
     * HowTo: https://docs.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-dotnet
     *        https://github.com/Azure-Samples/storage-blobs-dotnet-quickstart/blob/master/storage-blobs-dotnet-quickstart/Program.cs
     * NuGet: WindowsAzure.Storage
     */
    class DropBox
    {
        private readonly string _folder;

        public DropBox(string account, string folder)
        {
            Console.WriteLine($"DROPBOX DEMO ({account})");
            _folder = folder;
            // todo: blob container für account erstellen
        }

        public async Task StartAsync()
        {
            EnsureFolderExists();
            await EnsureAccountExists();
            await SyncFolderWithAccountAsync();
        }

        private void EnsureFolderExists()
        {
            if (!Directory.Exists(_folder) && AskFor($"Verzeichnis {_folder} existiert nicht, soll es erstellt werden?"))
                Directory.CreateDirectory(_folder);
        }

        private async Task EnsureAccountExists()
        {
            // todo: Sicherstellen, dass es einen Container für den Upload gibt
        }

        private async Task SyncFolderWithAccountAsync()
        {
            while (true)
            {
                // lokale Dateien
                var filePaths = Directory.GetFiles(_folder);
                var fileNames = filePaths.Select(t => new FileInfo(t)).Select(t => t.Name).ToArray();

                // todo: remote Dateien ermitteln
                // todo: fehlende Dateien hochladen
                // todo: fehlende Dateien runterladen

                // kurz warten
                await Task.Delay(2000);
            }
        }

        public static bool AskFor(string question)
        {
            Console.WriteLine($"{question} (y/n)");
            return Console.ReadKey().Key == ConsoleKey.Y;
        }
    }
}
