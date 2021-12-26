using EuropArt.Domain.Artists;
using EuropArt.Shared.Artists;
using EuropArt.Shared.Artworks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        /// <summary>
        /// Gets all the data from an artist
        /// </summary>
        [HttpGet]
        public Task<ArtistResponse.GetIndex> GetIndexAsync([FromQuery] ArtistRequest.GetIndex request)
        {
            return artistService.GetIndexAsync(request);
        }

        [HttpGet("android/")]
        public Task<List<ArtistDto.Detail>> GetArtistsAndroidAsync([FromQuery] ArtistRequest.GetIndex request)
        {
            return artistService.GetArtistsAndroidAsync(request);
        }

        /// <summary>
        /// Gets all the details of an artist
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Details of a the artist with the given ArtistId</returns>
        [HttpGet("{ArtistId}")]
        public Task<ArtistResponse.GetDetail> GetDetailAsync([FromRoute] ArtistRequest.GetDetail request)
        {
            return artistService.GetDetailAsync(request);
        }

        /// <summary>
        /// Gets all the details of an artist with their AuthId
        /// </summary>
        /// <param name="request">The authId from the artist who's detail need to be retrieved</param>
        /// <returns>Details of a the artist with the given AuthId</returns>
        [HttpGet("detail/{AuthId}")]
        public Task<ArtistResponse.GetDetailByAuthId> GetDetailByAuthIdAsync([FromRoute] ArtistRequest.GetDetailByAuthId request)
        {
            return artistService.GetDetailByAuthIdAsync(request);
        }

        /// <summary>
        /// Deletes an artist
        /// </summary>
        /// <param name="request">The Artistid from the artist who needs to be deleted</param>
        [HttpDelete("{ArtistId}")]
        public Task DeleteAsync([FromRoute] ArtistRequest.Delete request)
        {
            return artistService.DeleteAsync(request);
        }

        /// <summary>
        /// Adds a new artist
        /// </summary>
        /// <param name="request">The new artist</param>
        [HttpPost]
        public Task<ArtistResponse.Create> CreateAsync(ArtistRequest.Create request)
        {
            return artistService.CreateAsync(request);
        }

        /// <summary>
        /// Edits an artist
        /// </summary>
        /// <param name="request">The Id and the artist that needs to be edited</param>
        [HttpPut]
        public Task<ArtistResponse.Edit> EditAsync([FromBody] ArtistRequest.Edit request)
        {
            return artistService.EditAsync(request);
        }

    }
}
