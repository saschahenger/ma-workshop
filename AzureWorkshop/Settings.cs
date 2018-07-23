namespace AzureWorkshop
{
    class Settings
    {
        // todo:  mit gültigem ConnectionString aus dem Portal ersetzen
        // howto: https://docs.microsoft.com/en-us/azure/storage/common/storage-create-storage-account#manage-your-storage-access-keys
        // hinweis: container und queue namen sollten kleingeschrieben sein und keine Sonderzeichen besitzen
        public static string AzureConnectionString => "DefaultEndpointsProtocol=https;AccountName=<account>;AccountKey=<key>;EndpointSuffix=core.windows.net";
    }
}
