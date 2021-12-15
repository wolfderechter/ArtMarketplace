using EuropArt.Shared.Artists;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace EuropArt.Client.Infrastructure
{
    public class RegisterService
    {
        
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private IArtistService artistService { get; set; }
        [Inject] private AuthenticationStateProvider auth { get; set; }

        public async Task<ArtistResponse.Edit> EditAsync(string state, ArtistDto.Create newArtist)
        {
            return null;
            
        }
    }
}
