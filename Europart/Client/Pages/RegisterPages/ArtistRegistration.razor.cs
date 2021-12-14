using EuropArt.Client.Infrastructure;
using EuropArt.Shared.Artists;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
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
        [Inject] private RegisterService registerService { get; set; }
        public string domain { get; } = "https://dev-ixi3mmyx.eu.auth0.com";

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

            navigationManager.NavigateTo(domain + "/continue?state=" + state);
            /*ArtistRequest.Create request = new()
            {
                Artist = newArtist
            };

            var response = await artistService.CreateAsync(request);
            if (response != null)
            {

                var r = new ArtistRequest.GetDetail()
                {
                    ArtistId = response.ArtistId,
                };
                var a = await artistService.GetDetailAsync(r);
                var artist = a.Artist;

                var authState = await auth.GetAuthenticationStateAsync();
                var user = authState.User;


                ArtistDto.Edit edit = new ArtistDto.Edit()
                {
                    FirstName = artist.FirstName,
                    LastName = artist.LastName,
                    Biography = artist.Biography,
                    City = artist.City,
                    Country = artist.Country,
                    Postalcode = artist.Postalcode,
                    Street = artist.Street,
                    Website = artist.Website,
                    AuthId = user.Claims.ElementAt(4).Value
                };
                ArtistRequest.Edit editRequest = new ArtistRequest.Edit()
                {
                    Artist = edit,
                    ArtistId = response.ArtistId,
                };

                var editResponse = await artistService.EditAsync(editRequest);

                if (editResponse != null)
                {
                    Console.WriteLine("Register");

                }
            }*/
        }
    }
}
