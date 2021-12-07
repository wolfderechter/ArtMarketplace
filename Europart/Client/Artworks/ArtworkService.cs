using EuropArt.Client.Extensions;
using EuropArt.Shared.Artworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EuropArt.Client.Artworks
{
    public class ArtworkService : IArtworkService
    {
        private readonly HttpClient client;
        private const string endpoint = "api/Artwork";

        public ArtworkService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<ArtworkResponse.Create> CreateAsync(ArtworkRequest.Create request)
        {
            var response = await client.PostAsJsonAsync(endpoint, request);
            return await response.Content.ReadFromJsonAsync<ArtworkResponse.Create>();
        }

        //als ik een artiest verwijder moeten alle kunstwerken van hem ook verwijderd worden
        public async Task DeleteArtistAsync(int id)
        {
            await client.DeleteAsync($"{endpoint}/{id}");
        }

        public async Task DeleteAsync(ArtworkRequest.Delete request)
        {
            await client.DeleteAsync($"{endpoint}/{request.ArtworkId}");
        }

        public async Task<ArtworkResponse.Edit> EditAsync(ArtworkRequest.Edit request)
        {
            var response = await client.PutAsJsonAsync(endpoint, request);
            return await response.Content.ReadFromJsonAsync<ArtworkResponse.Edit>();
        }

        public async Task<ArtworkResponse.GetDetail> GetDetailAsync(ArtworkRequest.GetDetail request)
        {
            var response = await client.GetFromJsonAsync<ArtworkResponse.GetDetail>($"{endpoint}/{request.ArtworkId}");
            return response;
        }

        public async Task<ArtworkResponse.GetIndex> GetIndexAsync(ArtworkRequest.GetIndex request)
        {
            //not yet doing anything with the parameters from request
            //var response = await client.GetFromJsonAsync<ArtworkResponse.GetIndex>(endpoint);

            var queryParameters = request.GetQueryString();
            var response = await client.GetFromJsonAsync<ArtworkResponse.GetIndex>($"{endpoint}?{queryParameters}");
            return response;
        }
    }
}
