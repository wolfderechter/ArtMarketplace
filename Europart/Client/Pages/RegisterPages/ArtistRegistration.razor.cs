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
                    navigationManager.NavigateTo(domain + "/continue?state=" + state);
            }
        }
    }
}