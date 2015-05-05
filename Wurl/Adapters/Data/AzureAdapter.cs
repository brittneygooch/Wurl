using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Wurl.Models;

namespace Wurl.Adapters.Data
{
    public class AzureAdapter : IImageAdapter
    {
        private CloudStorageAccount StorageAccount { get; set; }
        private string ContainerName { get; set; }
        public AzureAdapter(CloudStorageAccount storageAccount, string containerName)
        {
            this.StorageAccount = storageAccount;
            this.ContainerName = containerName;
        }

        public async Task<IEnumerable<ImageVm>> Get()
        {
            CloudBlobClient blobClient = this.StorageAccount.CreateCloudBlobClient();
            CloudBlobContainer imageContainer = blobClient.GetContainerReference(this.ContainerName);

            if (!await imageContainer.ExistsAsync())
            {
                await imageContainer.CreateAsync(BlobContainerPublicAccessType.Blob, null, null);
            }

            var images = new List<ImageVm>();
            var blobItems = imageContainer.ListBlobs();

            foreach (CloudBlockBlob blob in blobItems.Where(b => b.GetType() == typeof(CloudBlockBlob)))
            {
                await blob.FetchAttributesAsync();

                images.Add(new ImageVm
                {
                    Name = blob.Name,
                    Size = blob.Properties.Length / 1024,
                    DateCreated = blob.Metadata["Created"] == null ? DateTime.Now : DateTime.Parse(blob.Metadata["Created"]),
                    DateModified = ((DateTimeOffset)blob.Properties.LastModified).DateTime,
                    Url = blob.Uri.AbsoluteUri
                });
            }
            return images;
        }

        public async Task<IEnumerable<ImageVm>> Add(HttpRequestMessage request)
        {
            CloudBlobClient blobClient = this.StorageAccount.CreateCloudBlobClient();
            CloudBlobContainer imageContainer = blobClient.GetContainerReference(this.ContainerName);

            var provider = new AzureBlobgMfDsP(imageContainer);

            await request.Content.ReadAsMultipartAsync(provider);

            var images = new List<ImageVm>();

            foreach (var file in provider.FileData)
            {
                var blob = await imageContainer.GetBlobReferenceFromServerAsync(file.LocalFileName);
                await blob.FetchAttributesAsync();

                images.Add(new ImageVm
                {
                    Name = blob.Name,
                    Size = blob.Properties.Length / 1024,
                    DateCreated = blob.Metadata["Created"] == null ? DateTime.Now : DateTime.Parse(blob.Metadata["Created"]),
                    DateModified = ((DateTimeOffset)blob.Properties.LastModified).DateTime,
                    Url = blob.Uri.AbsoluteUri
                });
            }

            return images;
        }

        public async Task<bool> FileExists(string fileName)
        {
            CloudBlobClient blobClient = this.StorageAccount.CreateCloudBlobClient();
            CloudBlobContainer imageContainer = blobClient.GetContainerReference(this.ContainerName);

            var blob = await imageContainer.GetBlobReferenceFromServerAsync(fileName);
            return await blob.ExistsAsync();
        }
    }
}