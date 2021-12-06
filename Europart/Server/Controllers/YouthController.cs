using EuropArt.Shared.YouthArtworks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropArt.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YouthController : ControllerBase
    {
        private readonly IYouthArtworkService youthArtworkService;

        public YouthController(IYouthArtworkService youthService)
        {
            this.youthArtworkService = youthService;
        }

        [HttpGet]
        public Task<YouthArtworkResponse.GetIndex> GetIndexAsync([FromQuery] YouthArtworkRequest.GetIndex request)
        {
            return youthArtworkService.GetIndexAsync(request);
        }

        [HttpGet("{YouthId}")]
        public Task<YouthArtworkResponse.GetDetail> GetDetailAsync([FromRoute] YouthArtworkRequest.GetDetail request)
        {
            return youthArtworkService.GetDetailAsync(request);
        }
    }
}
