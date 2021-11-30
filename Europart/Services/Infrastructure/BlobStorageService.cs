using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Microsoft.Extensions.Configuration;
using System;

namespace EuropArt.Services.Infrastructure
{
    public class BlobStorageService : IStorageService
    {
        private readonly string connectionString;
        private const string containerName = "images";

        public string StorageBaseUri => "https://demostoragehogent.blob.core.windows.net/images/";

        public BlobStorageService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Storage");
        }

        public Uri CreateUploadUri(string fileName, int artistId)
        {
            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(fileName);

            var blobSasBuilder = new BlobSasBuilder
            {
                //wanneer de sas moet vervallen
                ExpiresOn = DateTime.UtcNow.AddMinutes(5),
                BlobContainerName = containerName,
                BlobName = fileName
            };

            //flagged enum => | gebruiken om meerdere te hebben
            blobSasBuilder.SetPermissions(BlobSasPermissions.Write | BlobSasPermissions.Create | BlobSasPermissions.Read);

            var sas = blobClient.GenerateSasUri(blobSasBuilder);
            return sas;
        }
    }
}
