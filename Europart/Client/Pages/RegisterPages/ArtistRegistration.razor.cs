using EuropArt.Client.Infrastructure;
using EuropArt.Shared.Artists;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EuropArt.Client.Pages.RegisterPages
{
    partial class ArtistRegistration
    {
        private readonly IConfiguration _config;
        ArtistDto.Create newArtist = new() { };
        [Inject] private IArtistService artistService { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private AuthenticationStateProvider auth { get; set; }
        public string domain { get; } = "https://dev-ixi3mmyx.eu.auth0.com";
        [Parameter] public string AuthId { get; set; }
        [Parameter] public string state { get; set; }

        public ArtistRegistration()
        {

        }
        public ArtistRegistration(IConfiguration config)
        {
            _config = config;
        }
        public async Task SignUpAsync()
        {
            newArtist.DateCreated = DateTime.Now;
            newArtist.ImagePath = "/images/banner.jpg";
            newArtist.AuthId = AuthId;
            ArtistRequest.Create request = new()
            {
                Artist = newArtist
                
            };
            var response = await artistService.CreateAsync(request);
            if (response != null)
            {
                //get access token
                /*var client_token = new HttpClient();
                client_token.DefaultRequestHeaders.Add("content-type", "application/x-www-form-urlencoded");
                string url = "https://dev-ixi3mmyx.eu.auth0.com/oauth/token";
                HttpContent content = new HttpContent();
                var response = await client_token.PostAsync(url, )
                request_token.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials&client_id=%24%7Baccount.clientId%7D&client_secret=4_mtL9Va848ryzxIBTDCuFeirOrda3cf0hb-90oNoSEMedDVyfAxASzjoUwrR0F2&audience=https%3A%2F%2F%24%7Baccount.namespace%7D%2Fapi%2Fv2%2F", ParameterType.RequestBody);
                IRestResponse response_token = client_token.Execute(request_token);
                //add notverified claim to user
                var client = new RestClient("https://dev-ixi3mmyx.eu.auth0.com/api/v2/users/" + "auth0|" + AuthId + "/roles");
                var req = new RestRequest(Method.POST);
                req.AddHeader("content-type", "application/json");
                req.AddHeader("authorization", "Bearer" + response_token);
                req.AddHeader("cache-control", "no-cache");
                req.AddParameter("application/json", "{ \"roles\": [ \"rol_dRX5AMGFoDWe8tao\" ] }", ParameterType.RequestBody);
                IRestResponse res = client.Execute(req);*/
                /*if(res != null)
                {*/
                    navigationManager.NavigateTo(domain + "/continue?state=" + state);
                /*}*/
            }
        }
    }
}