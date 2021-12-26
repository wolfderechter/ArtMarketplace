using EuropArt.Shared.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EuropArt.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        public UserController(IUserService userservice)
        {
            userService = userservice;
        }

        [HttpGet("index/{AuthId}")]
        public Task<UserResponse.GetIndex> GetIndexAsync([FromRoute] UserRequest.GetIndex request)
        {
            return userService.GetIndexAsync(request);
        }

        [HttpPost]
        public Task<UserResponse.Create> CreateAsync(UserRequest.Create request)
        {
            return userService.CreateAsync(request);
        }
    }
}
