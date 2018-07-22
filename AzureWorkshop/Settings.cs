namespace AzureWorkshop
{
    class Settings
    {
        // A storage account can contain an unlimited number of containers, and a container can store an unlimited number of blobs, container name must be lowercase.
        // A container is similar to a folder in a file system
        // http://<storage account>.queue.core.windows.net/<queue> 
        // todo: mit gültigem ConnectionString aus dem Portal ersetzen
        // siehe: https://docs.microsoft.com/en-us/azure/storage/common/storage-create-storage-account#manage-your-storage-access-keys
        public static string AzureConnectionString => "DefaultEndpointsProtocol=https;AccountName=<account>;AccountKey=<key>;EndpointSuffix=core.windows.net";

    }
}
