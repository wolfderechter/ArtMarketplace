using EuropArt.Shared.Accounts;
using EuropArt.Shared.Artists;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EuropArt.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        /// <summary>
        /// Adds a like
        /// </summary>
        /// <param name="request">the new Like</param>
        [HttpPost]
        public Task AddLikeAsync([FromBody] AccountRequest.AddLike request)
        {
            return accountService.AddLikeAsync(request);
        }

        /// <summary>
        /// Get all the likes of a specific user 
        /// </summary>
        /// <param name="request">The authId from the user whose likes are to be retrieved</param>
        /// <returns>All the likes of a user</returns>
        [HttpGet("{AuthId}")]
        public Task<AccountResponse.GetLikes> GetLikesAsync([FromRoute] AccountRequest.GetLikes request)
        {
            return accountService.GetLikesAsync(request);
        }

        /// <summary>
        /// Deletes a like
        /// </summary>
        /// <param name="request">The authId of the</param>
        [HttpDelete("{AuthId}/{ArtworkId}")]
        public Task DeleteAsync([FromRoute] AccountRequest.DeleteLike request)
        {
            return accountService.DeleteLikeAsync(request);
        }

        /// <summary>
        /// Gets al the conversations of a specific user
        /// </summary>
        /// <param name="request">The authId of the artist who's conversations need to be fetched</param>
        /// <returns>all the coversations of a user</returns>
        [HttpGet("messages/{AuthId}")]
        public Task<AccountResponse.GetConversations> GetConversationsAsync([FromRoute] AccountRequest.GetConversations request)
        {
            return accountService.GetConversationsAsync(request);
        }

        /// <summary>
        /// Gets all the data from a user
        /// </summary>
        /// <param name="request">The AuthId of the user who's data needs to get retrieved</param>
        /// <returns>Data of a user</returns>
        [HttpGet("index/{AuthId}")]
        public Task<AccountResponse.GetIndexAccount> GetIndexAsync([FromRoute] AccountRequest.GetIndex request)
        {
            return accountService.GetIndexAsync(request);
        }

        /// <summary>
        /// Adds a message to a conversation
        /// </summary>
        /// <param name="request">The id of the conversation where the message needs to be added</param>
        [HttpPost("AddMessageAsync")]
        public Task AddMessageAsync([FromBody] AccountRequest.AddMessage request)
        {
            return accountService.AddMessageAsync(request);
        }

        /// <summary>
        /// Makes a new conversation between user and artist
        /// </summary>
        /// <param name="request">The authId of the user and artist between whom the conversation should be started</param>
        [HttpPost("AddConversationAsync")]
        public Task StartConversationAsync([FromBody] AccountRequest.StartConversation request)
        {
            return accountService.StartConversationAsync(request);
        }

    }
}
