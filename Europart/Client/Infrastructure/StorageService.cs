using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EuropArt.Client.Infrastructure
{
    public class StorageService
    {
        private readonly HttpClient httpClient;
        public const long maxFileSize = 1024 * 1024 * 10;

        public StorageService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task UploadImageAsync(Uri uploadPath, IBrowserFile file)
        {
            var content = new StreamContent(file.OpenReadStream(maxFileSize));
            content.Headers.Add("x-ms-blob-type", "BlockBlob");

            var response = await httpClient.PutAsync(uploadPath, content);
            response.EnsureSuccessStatusCode();
        }
    }
}
