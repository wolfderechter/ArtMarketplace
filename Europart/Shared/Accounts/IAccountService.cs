using EuropArt.Shared.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Accounts
{
    public interface IAccountService 
    {
        Task AddLikeAsync(AccountRequest.AddLike request);
        Task<AccountResponse.GetLikes> GetLikesAsync(AccountRequest.GetLikes request);
        Task DeleteLikeAsync(AccountRequest.DeleteLike request);
        Task<AccountResponse.GetConversations> GetConversationsAsync(AccountRequest.GetConversations request);
    }
}
