using EuropArt.Shared.Artists;
using EuropArt.Shared.Artworks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EuropArt.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService artistService;

        public ArtistController(IArtistService artistService)
        {
            this.artistService = artistService;
        }

        [HttpGet]
        public Task<ArtistResponse.GetIndex> GetIndexAsync([FromQuery] ArtistRequest.GetIndex request)
        {
            return artistService.GetIndexAsync(request);
        }

        [HttpGet("{ArtistId}")]
        public Task<ArtistResponse.GetDetail> GetDetailAsync([FromRoute] ArtistRequest.GetDetail request)
        {
            return artistService.GetDetailAsync(request);
        }

        [HttpDelete("{ArtistId}")]
        public Task DeleteAsync([FromRoute] ArtistRequest.Delete request)
        {
            return artistService.DeleteAsync(request);
        }

        //[HttpPost]
        //public Task<ArtistResponse.Create> CreateAsync(ArtistRequest.Create request)
        //{
        //    return artistService.CreateAsync(request);
        //}
    }
}
