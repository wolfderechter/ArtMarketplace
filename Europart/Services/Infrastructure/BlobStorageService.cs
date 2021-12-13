using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Threading.Tasks;

namespace EuropArt.Services.Infrastructure
{
    public class BlobStorageService : IStorageService
    {
        private readonly string connectionString;
        private const string containerNameArtworks = "artworks";
        private const string containerNameProfilePictures = "profilepictures";

        public string StorageBaseUri => "https://demostoragehogent.blob.core.windows.net/";

        public BlobStorageService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Storage");
        }

        public Uri CreateUploadUriArtworks(string fileName)
        {
            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerNameArtworks);
            var blobClient = containerClient.GetBlobClient(fileName);

            var blobSasBuilder = new BlobSasBuilder
            {
                //wanneer de sas moet vervallen
                ExpiresOn = DateTime.UtcNow.AddMinutes(5),
                BlobContainerName = containerNameArtworks,
                BlobName = fileName
            };

            //flagged enum => | gebruiken om meerdere te hebben
            blobSasBuilder.SetPermissions(BlobSasPermissions.Write | BlobSasPermissions.Create | BlobSasPermissions.Read);

            var sas = blobClient.GenerateSasUri(blobSasBuilder);
            return sas;
        }
        public Uri CreateUploadUriProfilePictures(string fileName)
        {
            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerNameProfilePictures);
            var blobClient = containerClient.GetBlobClient(fileName);

            var blobSasBuilder = new BlobSasBuilder
            {
                //wanneer de sas moet vervallen
                ExpiresOn = DateTime.UtcNow.AddMinutes(5),
                BlobContainerName = containerNameProfilePictures,
                BlobName = fileName
            };

            //flagged enum => | gebruiken om meerdere te hebben
            blobSasBuilder.SetPermissions(BlobSasPermissions.Write | BlobSasPermissions.Create | BlobSasPermissions.Read);

            var sas = blobClient.GenerateSasUri(blobSasBuilder);
            return sas;
        }

        public void DeleteArtworksImage(string fileName)
        {
            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerNameArtworks);
            containerClient.GetBlobClient(fileName).DeleteIfExists();

        }
        public void DeleteProfilePictureImage(string fileName)
        {
            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerNameProfilePictures);
            var blob = containerClient.GetBlobClient(fileName);
            blob.DeleteIfExists();

            //CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
            //CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            //CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(containerNameProfilePictures);
            //var blob = cloudBlobContainer.GetBlobReference(fileName);
            //return await blob.DeleteIfExistsAsync();
        }
    }
}
