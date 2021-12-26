using EuropArt.Shared.YouthArtists;
using EuropArt.Shared.YouthArtworks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropArt.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class YouthArtworkController : ControllerBase
    {
        private readonly IYouthArtworkService youthArtworkService;

        public YouthArtworkController(IYouthArtworkService youthService)
        {
            this.youthArtworkService = youthService;
        }

        /// <summary>
        /// Gets the data of an youthartwork
        /// </summary>
        [HttpGet]
        public Task<YouthArtworkResponse.GetIndex> GetIndexAsync([FromQuery] YouthArtworkRequest.GetIndex request)
        {
            return youthArtworkService.GetIndexAsync(request);
        }

        [HttpGet("android/")]
        public Task<List<YouthArtworkDto.Detail>> GetYouthArtworksAndroidAsync([FromQuery] YouthArtworkRequest.GetIndex request)
        {
            return youthArtworkService.GetYouthArtworksAndroidAsync(request);
        }

        /// <summary>
        /// Gets the details of an youthartwork
        /// </summary>
        /// <param name="request">The id of the youthArtwork who's data needs to bee retrieved </param>
        [HttpGet("{YouthArtworkId}")]  
        public Task<YouthArtworkResponse.GetDetail> GetDetailAsync([FromRoute] YouthArtworkRequest.GetDetail request)
        {
            return youthArtworkService.GetDetailAsync(request);
        }
    }
}
