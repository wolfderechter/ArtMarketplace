using EuropArt.Client.Infrastructure;
using EuropArt.Shared.Artists;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;


namespace EuropArt.Client.Pages.RegisterPages
{
    partial class ArtistRegistration
    {
        private readonly IConfiguration _config;
        ArtistDto.Create newArtist = new() { };
        [Inject] private IArtistService artistService { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private RegisterService registerService { get; set; }
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
            /*newArtist.AuthId = */

            ArtistRequest.Create request = new()
            {
                Artist = newArtist
            };

            var response = await artistService.CreateAsync(request);
            string domain = registerService.domain;
            navigationManager.NavigateTo(domain + "/continue?state=" + state);
        }
    }
}
