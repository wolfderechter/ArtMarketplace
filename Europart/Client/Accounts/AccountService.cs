using EuropArt.Client.Infrastructure;
using EuropArt.Shared.Accounts;
using EuropArt.Shared.Artists;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EuropArt.Client.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient client;
        private readonly PublicClient publicClient;
        private const string endpoint = "api/account";
        public AccountService(HttpClient client, PublicClient publicClient)
        {
            this.client = client;
            this.publicClient = publicClient;
        }
        public async Task AddLikeAsync(AccountRequest.AddLike request)
        {
            await client.PostAsJsonAsync(endpoint, request);
        }

        public async Task<AccountResponse.GetLikes> GetLikesAsync(AccountRequest.GetLikes request)
        {
            var response = await client.GetFromJsonAsync<AccountResponse.GetLikes>($"{endpoint}/{request.AuthId}");
            return response;
        }

        public async Task DeleteLikeAsync(AccountRequest.DeleteLike request)
        {
            await client.DeleteAsync($"{endpoint}/{request.AuthId}/{request.ArtworkId}");
        }

        public async Task<AccountResponse.GetConversations> GetConversationsAsync(AccountRequest.GetConversations request)
        {
            var response = await client.GetFromJsonAsync<AccountResponse.GetConversations>($"{endpoint}/messages/{request.AuthId}");
            return response;
        }

        public async Task<AccountResponse.GetIndex> GetIndexAsync(AccountRequest.GetIndex request)
        {
            var response = await client.GetFromJsonAsync<AccountResponse.GetIndex>($"{endpoint}/index/{request.AuthId}");
            return response;
        }

        public async Task AddMessageAsync(AccountRequest.AddMessage request)
        {
            await client.PostAsJsonAsync($"{endpoint}/AddMessageAsync", request);
        }
    }
}
