using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace AzureWorkshop.BlobDemo.DropBox
{
    class DropBox
    {
        // todo: https://docs.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-dotnet

        readonly string _azureStorageConnectionString;
        readonly string _dropBoxAccount;
        readonly string _dropBoxFolder;

        public DropBox(string account, string folder)
        {
            _azureStorageConnectionString = Settings.AzureConnectionString;
            _dropBoxAccount = account;
            _dropBoxFolder = folder;
        }

        public void Start()
        {
            EnsureFolderExists();
            EnsureAccountExists();
            SyncFolderWithAccount();
        }

        void EnsureFolderExists()
        {
            if (!Directory.Exists(_dropBoxFolder) && Settings.AskFor($"Verzeichnis {_dropBoxFolder} existiert nicht, soll es erstellt werden?"))
                Directory.CreateDirectory(_dropBoxFolder);
        }

        void EnsureAccountExists()
        {
            // todo: überprüfen, ob es einen Azure Blob Container mit diesem Namen gibt und wenn nicht, erstellen
        }

        void SyncFolderWithAccount()
        {
            while (true)
            {
                // note: das Löschen und Synchronisieren von gelöschten Dateien unterstützen wir nicht
                // todo: alle Dateien aus dem Verzeichnis sollen auch in der Cloud existieren
                // todo: alle Dateien aus der Cloud sollen auch im Verzeichnis existieren
                Thread.Sleep(TimeSpan.FromSeconds(3));
            }
        }

        public void Stop()
        {

        }
    }
}
