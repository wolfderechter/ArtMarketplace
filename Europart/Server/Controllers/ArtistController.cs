using EuropArt.Shared.Artists;
using EuropArt.Shared.Artworks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EuropArt.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
/*
        [HttpGet("{ArtistId}")]
        public Task<ArtistResponse.GetDetail> GetDetailAsync([FromRoute] ArtistRequest.GetDetail request)
        {
            return artistService.GetDetailAsync(request);
        }*/

        [HttpGet("{AuthId}")]
        public Task<ArtistResponse.GetDetailByAuthId> GetDetailByAuthIdAsync([FromRoute] ArtistRequest.GetDetailByAuthId request)
        {
            return artistService.GetDetailByAuthIdAsync(request);
        }

        [HttpDelete("{ArtistId}")]
        public Task DeleteAsync([FromRoute] ArtistRequest.Delete request)
        {
            return artistService.DeleteAsync(request);
        }

        [HttpPost]
        public Task<ArtistResponse.Create> CreateAsync(ArtistRequest.Create request)
        {
            return artistService.CreateAsync(request);
        }

        [HttpPut]
        public Task<ArtistResponse.Edit> EditAsync([FromBody] ArtistRequest.Edit request)
        {
            return artistService.EditAsync(request);
        }

        [HttpGet("{AuthId}/{email}")]
        public Task EditAuth0(string AuthId, string email)
        {
            var authid = AuthId;
            var Email = email;
            return null;
        }
    }
}
