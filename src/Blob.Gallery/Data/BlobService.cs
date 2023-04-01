using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;


namespace Blob.Gallery.Data
{
    public class BlobService
    {
        private readonly IConfiguration _configuration;

        public BlobService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<BlobClient> GetBlobs()
        {
            var blobClients = new List<BlobClient>();
            var blobServiceClient = new BlobServiceClient(_configuration["BlobGalleryConnectionString"]);
            var bloblContainerClient = blobServiceClient.GetBlobContainerClient("weddinggallery");
            var blobs = bloblContainerClient.GetBlobs();
            foreach (var blob in blobs)
            {
                blobClients.Add(bloblContainerClient.GetBlobClient(blob.Name));
            }
            return blobClients;
        }
    }
}
