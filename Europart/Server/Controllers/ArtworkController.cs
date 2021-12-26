using EuropArt.Domain.Artworks;
using EuropArt.Shared.Artworks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EuropArt.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtworkController : ControllerBase
    {
        private readonly IArtworkService artworkService;

        public ArtworkController(IArtworkService artworkService)
        {
            this.artworkService = artworkService;
        }

        /// <summary>
        /// Gets data of an artwork
        /// </summary>
        /// <returns>Data of an artwork with the given artworkId</returns>
        [HttpGet]
        public Task<ArtworkResponse.GetIndex> GetIndexAsync([FromQuery] ArtworkRequest.GetIndex request)
        {
            return artworkService.GetIndexAsync(request);
        }

        [HttpGet("android/")]
        public Task<List<ArtworkDto.Detail>> GetArtworksAndroidAsync([FromQuery] ArtworkRequest.GetIndex request)
        {
            return artworkService.GetArtworksAndroidAsync(request);
        }

        /// <summary>
        /// Gets the datails of an artwork
        /// </summary>
        /// <param name="request">The id of the artwork that needs to be retrieved</param>
        /// <returns>Details of a the artwork with the given ArtworkId</returns>
        [HttpGet("{ArtworkId}")]
        public Task<ArtworkResponse.GetDetail> GetDetailAsync([FromRoute] ArtworkRequest.GetDetail request)
        {
            return artworkService.GetDetailAsync(request);
        }

        /// <summary>
        /// Deletes an artwork
        /// </summary>
        /// <param name="request">The id of the artwork that needs to be deleted</param>
        [HttpDelete("{ArtworkId}")]
        public Task DeleteAsync([FromRoute] ArtworkRequest.Delete request)
        {
            return artworkService.DeleteAsync(request);
        }

        /// <summary>
        /// Adds a new artwork
        /// </summary>
        [HttpPost]
        public Task<ArtworkResponse.Create> CreateAsync(ArtworkRequest.Create request)
        {
            return artworkService.CreateAsync(request);
        }

        /// <summary>
        /// Edits an artwork
        /// </summary>
        [HttpPut]
        public Task<ArtworkResponse.Edit> EditAsync([FromBody]ArtworkRequest.Edit request)
        {
            return artworkService.EditAsync(request);
        }
    }
}
