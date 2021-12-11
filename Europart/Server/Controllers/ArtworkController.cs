using EuropArt.Shared.Artworks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EuropArt.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class ArtworkController : ControllerBase
    {
        private readonly IArtworkService artworkService;

        public ArtworkController(IArtworkService artworkService)
        {
            this.artworkService = artworkService;
        }

        [HttpGet]
        public Task<ArtworkResponse.GetIndex> GetIndexAsync([FromQuery] ArtworkRequest.GetIndex request)
        {
            return artworkService.GetIndexAsync(request);
        }

        [HttpGet("{ArtworkId}")]
        public Task<ArtworkResponse.GetDetail> GetDetailAsync([FromRoute] ArtworkRequest.GetDetail request)
        {
            return artworkService.GetDetailAsync(request);
        }

        [HttpDelete("{ArtworkId}")]
        public Task DeleteAsync([FromRoute] ArtworkRequest.Delete request)
        {
            return artworkService.DeleteAsync(request);
        }

        [HttpPost]
        public Task<ArtworkResponse.Create> CreateAsync(ArtworkRequest.Create request)
        {
            return artworkService.CreateAsync(request);
        }

        //[HttpDelete("{ArtistId}")]
        //public Task DeleteArtistAsync([FromRoute] int ArtistId)
        //{
        //    return artworkService.DeleteArtistAsync(ArtistId);
        //}

        [HttpPut]
        public Task<ArtworkResponse.Edit> EditAsync([FromBody]ArtworkRequest.Edit request)
        {
            return artworkService.EditAsync(request);
        }
    }
}
