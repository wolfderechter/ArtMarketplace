using EuropArt.Client.Infrastructure;
using EuropArt.Shared.Users;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EuropArt.Client.Users
{
    public class UserService : IUserService
    {
        private readonly HttpClient client;
        private readonly PublicClient publicClient;
        private const string endpoint = "api/user";
        public UserService(HttpClient client, PublicClient publicClient)
        {
            this.client = client;
            this.publicClient = publicClient;
        }
        public async Task<UserResponse.Create> CreateAsync(UserRequest.Create request)
        {
            var response = await publicClient.Client.PostAsJsonAsync(endpoint, request);
            return await response.Content.ReadFromJsonAsync<UserResponse.Create>();
        }

        public async Task<UserResponse.GetIndex> GetIndexAsync(UserRequest.GetIndex request)
        {
            var response = await client.GetFromJsonAsync<UserResponse.GetIndex>($"{endpoint}/index/{request.AuthId}");
            return response;
        }

        public bool CheckIfUser(string authId)
        {
            throw new System.NotImplementedException();
        }
    }
}
