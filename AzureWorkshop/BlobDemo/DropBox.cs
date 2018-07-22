using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AzureWorkshop.BlobDemo
{
    /*
     * Todo:  alle Dateien aus dem Verzeichnis sollen auch in der Cloud existieren
     *        alle Dateien aus der Cloud sollen auch im Verzeichnis existieren
     *        das Löschen und Synchronisieren von gelöschten Dateien unterstützen wir nicht
     *        oder wenn sich Dateien geändert haben
     *
     * HowTo: https://docs.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-dotnet
     *        https://github.com/Azure-Samples/storage-blobs-dotnet-quickstart/blob/master/storage-blobs-dotnet-quickstart/Program.cs
     * NuGet: WindowsAzure.Storage
     */
    class DropBox
    {
        private CloudBlobClient _client;
        private CloudBlobContainer _container;
        readonly string _dropBoxAccount;
        readonly string _folder;

        public DropBox(string account, string folder)
        {
            _dropBoxAccount = account;
            this._folder = folder;
            _client = CloudStorageAccount.Parse(Settings.AzureConnectionString).CreateCloudBlobClient();
            _container = _client.GetContainerReference(_dropBoxAccount);
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
                var localFiles = Directory.GetFiles(_folder);
                var localFileNames = localFiles.Select(t => new FileInfo(t)).Select(t => t.Name).ToArray();

                // remote Dateien
                var remoteFiles = (await _container.ListBlobsSegmentedAsync(null)).Results.ToArray();
                var remoteFileNames = remoteFiles.Select(t => (CloudBlockBlob) t).Select(t => t.Name).ToArray();

                // fehlende Dateien hochladen
                var filesToUpload = localFileNames.Except(remoteFileNames);
                foreach (var fileToUpload in filesToUpload)
                {
                    var file = localFiles.First(t => t.EndsWith(fileToUpload));
                    var blockBlob = _container.GetBlockBlobReference(fileToUpload);
                    await blockBlob.UploadFromFileAsync(file);
                }

                // fehlende Dateien herunterladen
                var filesToDownload = remoteFileNames.Except(localFileNames);
                foreach (var fileToDownload in filesToDownload)
                {
                    var file = remoteFiles.First(t => t.Uri.ToString().EndsWith(fileToDownload));
                    var blockBlob = _container.GetBlockBlobReference(fileToDownload);
                    await blockBlob.DownloadToFileAsync(Path.Combine(_folder, fileToDownload), FileMode.Create);
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
