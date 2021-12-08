using EuropArt.Client.Extensions;
using EuropArt.Shared.YouthArtists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EuropArt.Client.Youths
{
   
    public class YouthArtistService : IYouthArtistService
    {

        private readonly HttpClient client;
        private const string endpoint = "api/YouthArtist";
        public Task DeleteAsync(YouthArtistRequest.Delete request)
        {
            throw new NotImplementedException();
        }

        public Task<YouthArtistResponse.Edit> EditAsync(YouthArtistRequest.Edit request)
        {
            throw new NotImplementedException();
        }

        public async Task<YouthArtistResponse.GetDetail> GetDetailAsync(YouthArtistRequest.GetDetail request)
        {
            var response = await client.GetFromJsonAsync<YouthArtistResponse.GetDetail>($"{endpoint}/{request.YouthArtistId}");
            return response;
        }

        public async Task<YouthArtistResponse.GetIndex> GetIndexAsync(YouthArtistRequest.GetIndex request)
        {
            var queryParameters = request.GetQueryString();
            var response = await client.GetFromJsonAsync<YouthArtistResponse.GetIndex>($"{endpoint}?{queryParameters}");
            return response;

        }
    }
}
