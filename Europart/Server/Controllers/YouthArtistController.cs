using EuropArt.Services.Youths;
using EuropArt.Shared.YouthArtists;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropArt.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YouthArtistController : ControllerBase
    {
        private readonly IYouthArtistService youthArtistService;
        public YouthArtistController(IYouthArtistService youthArtistService)
        {
            this.youthArtistService = youthArtistService;
        }
        [HttpGet]
        public Task<YouthArtistResponse.GetIndex> GetIndexAsync([FromQuery] YouthArtistRequest.GetIndex request)
        {
            return youthArtistService.GetIndexAsync(request);
        }

        [HttpGet("{YouthArtistId}")]
        public Task<YouthArtistResponse.GetDetail> GetDetailAsync([FromRoute] YouthArtistRequest.GetDetail request)
        {
            return youthArtistService.GetDetailAsync(request);
        }

        [HttpDelete("{YouthArtistId}")]
        public Task DeleteAsync([FromRoute] YouthArtistRequest.Delete request)
        {
            return youthArtistService.DeleteAsync(request);
        }
    }
}
