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
        public void GetBlobs()
        {
            var blobServiceClient = new BlobServiceClient(_configuration["BlobGalleryConnectionString"]);
            var bloblContainerClient = blobServiceClient.GetBlobContainerClient("weddinggallery");
            var blobs = bloblContainerClient.GetBlobs();
            foreach (var blob in blobs)
            {
                var blobClient = bloblContainerClient.GetBlobClient(blob.Name);
                using (var ms = new MemoryStream())
                {
                    blobClient.DownloadTo(ms);
                    var name = blobClient.Name;
                    var data = ms.ToArray();
                }
            }
        }
    }
}
