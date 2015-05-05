using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Wurl.Adapters.Data
{
    public class AzureBlobgMfDsP : MultipartFormDataStreamProvider
    {
        private CloudBlobContainer BlobContainer { get; set; }
        public AzureBlobgMfDsP(CloudBlobContainer blobContainer)
            : base("azure")
        {
            this.BlobContainer = blobContainer;
        }

        public override Stream GetStream(HttpContent parent, System.Net.Http.Headers.HttpContentHeaders headers)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }
            if (headers == null)
            {
                throw new ArgumentNullException("headers");
            }

            var fileName = this.GetLocalFileName(headers);

            CloudBlockBlob blob = this.BlobContainer.GetBlockBlobReference(fileName);
            blob.Metadata["Created"] = DateTime.Now.ToString();

            if (headers.ContentType != null)
            {
                blob.Properties.ContentType = headers.ContentType.MediaType;
            }

            this.FileData.Add(new MultipartFileData(headers, blob.Name));

            return blob.OpenWrite();
        }

        public override Task ExecutePostProcessingAsync()
        {
            return base.ExecutePostProcessingAsync();
        }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : "Unnamed";
            name = name.Trim(new char[] { '"' }).Replace("&", "and");

            // For users using IE
            name = Path.GetFileName(name);

            return name;
        }
    }
}