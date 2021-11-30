using EuropArt.Shared.Youths;
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
        private readonly IYouthService youthService;

        public YouthController(IYouthService youthService)
        {
            this.youthService = youthService;
        }

        [HttpGet]
        public Task<YouthResponse.GetIndex> GetIndexAsync([FromQuery] YouthRequest.GetIndex request)
        {
            return youthService.GetIndexAsync(request);
        }

        [HttpGet("{YouthId}")]
        public Task<YouthResponse.GetDetail> GetDetailAsync([FromRoute] YouthRequest.GetDetail request)
        {
            return youthService.GetDetailAsync(request);
        }
    }
}
