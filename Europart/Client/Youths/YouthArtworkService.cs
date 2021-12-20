using EuropArt.Client.Infrastructure;
using EuropArt.Shared.YouthArtworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EuropArt.Client.Youths
{
    public class YouthArtworkService : IYouthArtworkService
    {
        private readonly HttpClient client;
        private readonly PublicClient publicClient;   
        private const string endpoint = "api/YouthArtwork";
        public YouthArtworkService(HttpClient client, PublicClient publicClient)
        {
            this.client = client;
            this.publicClient = publicClient;
        }
        public async Task<YouthArtworkResponse.GetDetail> GetDetailAsync(YouthArtworkRequest.GetDetail request)
        {
            var response = await publicClient.Client.GetFromJsonAsync<YouthArtworkResponse.GetDetail>($"{endpoint}/{request.YouthArtworkId}");
            return response;
        }
        public async Task<YouthArtworkResponse.GetIndex> GetIndexAsync(YouthArtworkRequest.GetIndex request)
        {
            var response = await publicClient.Client.GetFromJsonAsync<YouthArtworkResponse.GetIndex>(endpoint);
            return response;
        }
    }
}