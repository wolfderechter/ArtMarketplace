using EuropArt.Client.Extensions;
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
        private const string endpoint = "api/Artist";
        public ArtistService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<ArtistResponse.GetIndex> GetIndexAsync(ArtistRequest.GetIndex request)
        {
            //not doing anything with the request
            //var response = await client.GetFromJsonAsync<ArtistResponse.GetIndex>(endpoint);

            var queryParameters = request.GetQueryString();
            var response = await client.GetFromJsonAsync<ArtistResponse.GetIndex>($"{endpoint}?{queryParameters}");
            return response;
        }

        //skip
        public Task<List<ArtistDto.Index>> GetIndexAsync(string searchterm)
        {
            throw new NotImplementedException();
        }

        public async Task<ArtistResponse.GetDetail> GetDetailAsync(ArtistRequest.GetDetail request)
        {
            var response = await client.GetFromJsonAsync<ArtistResponse.GetDetail>($"{endpoint}/{request.ArtistId}");
            return response;
        }

        //nog implementeren
        public Task<ArtistResponse.Edit> EditAsync(ArtistRequest.Edit request)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(ArtistRequest.Delete request)
        {
            await client.DeleteAsync($"{endpoint}/{request.ArtistId}");
        }
    }
}
