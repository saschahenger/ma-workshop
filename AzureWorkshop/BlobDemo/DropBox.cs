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
        private readonly CloudBlobContainer _container;
        private readonly string _folder;

        public DropBox(string account, string folder)
        {
            _folder = folder;
            _container = CloudStorageAccount.Parse(Settings.AzureConnectionString)
                .CreateCloudBlobClient()
                .GetContainerReference(account);
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
            await _container.CreateIfNotExistsAsync();
        }

        private async Task SyncFolderWithAccountAsync()
        {
            while (true)
            {
                // lokale Dateien
                var filePaths = Directory.GetFiles(_folder);
                var fileNames = filePaths.Select(t => new FileInfo(t)).Select(t => t.Name).ToArray();

                // remote Dateien
                var blobItems = (await _container.ListBlobsSegmentedAsync(null)).Results.ToArray();
                var blobNames = blobItems.Select(t => (CloudBlockBlob) t).Select(t => t.Name).ToArray();

                // fehlende Dateien hochladen
                var uploads = fileNames.Except(blobNames);
                foreach (var upload in uploads)
                {
                    var path = filePaths.First(t => t.EndsWith(upload));
                    var blobReference = _container.GetBlockBlobReference(upload);
                    await blobReference.UploadFromFileAsync(path);
                }

                // fehlende Dateien runterladen
                var downloads = blobNames.Except(fileNames);
                foreach (var download in downloads)
                {
                    var blobReference = _container.GetBlockBlobReference(download);
                    await blobReference.DownloadToFileAsync(Path.Combine(_folder, download), FileMode.Create);
                }

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
