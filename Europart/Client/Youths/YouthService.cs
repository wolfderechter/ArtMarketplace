using EuropArt.Shared.Youths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EuropArt.Client.Youths
{
    public class YouthService : IYouthService
    {
        private readonly HttpClient client;
        private const string endpoint = "api/Youth";

        public YouthService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<YouthResponse.GetDetail> GetDetailAsync(YouthRequest.GetDetail request)
        {
            var response = await client.GetFromJsonAsync<YouthResponse.GetDetail>($"{endpoint}/{request.YouthId}");
            return response;

        }

        public async Task<YouthResponse.GetIndex> GetIndexAsync(YouthRequest.GetIndex request)
        {
            var response = await client.GetFromJsonAsync<YouthResponse.GetIndex>(endpoint);
            return response;
        }
    }
}
