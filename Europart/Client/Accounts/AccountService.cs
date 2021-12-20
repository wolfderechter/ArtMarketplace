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
    }
}
