using EuropArt.Client.Extensions;
using EuropArt.Client.Infrastructure;
using EuropArt.Shared.Artists;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EuropArt.Client.Artists
{
    public class ArtistService : IArtistService
    {
        private readonly HttpClient client;
        private readonly PublicClient publicClient;
        private const string endpoint = "api/Artist";
        public ArtistService(HttpClient client, PublicClient publicClient)
        {
            this.client = client;
            this.publicClient = publicClient;
        }

        public async Task<ArtistResponse.GetIndex> GetIndexAsync(ArtistRequest.GetIndex request)
        {
            //not doing anything with the request
            //var response = await client.GetFromJsonAsync<ArtistResponse.GetIndex>(endpoint);

            var queryParameters = request.GetQueryString();
            var response = await publicClient.Client.GetFromJsonAsync<ArtistResponse.GetIndex>($"{endpoint}?{queryParameters}");
            return response;
        }

        //skip
        public Task<List<ArtistDto.Index>> GetIndexAsync(string searchterm)
        {
            throw new NotImplementedException();
        }

        public async Task<ArtistResponse.GetDetail> GetDetailAsync(ArtistRequest.GetDetail request)
        {
            var response = await publicClient.Client.GetFromJsonAsync<ArtistResponse.GetDetail>($"{endpoint}/{request.ArtistId}");
            return response;
        }

        public async Task<ArtistResponse.Edit> EditAsync(ArtistRequest.Edit request)
        {
            var response = await client.PutAsJsonAsync(endpoint, request);
            return await response.Content.ReadFromJsonAsync<ArtistResponse.Edit>();
        }

        public async Task DeleteAsync(ArtistRequest.Delete request)
        {
            await client.DeleteAsync($"{endpoint}/{request.ArtistId}");
        }

        public async Task<ArtistResponse.Create> CreateAsync(ArtistRequest.Create request)
        {
            var response = await publicClient.Client.PostAsJsonAsync(endpoint, request);
            return await response.Content.ReadFromJsonAsync<ArtistResponse.Create>();
        }
    }
}
