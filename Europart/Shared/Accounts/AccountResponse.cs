using EuropArt.Domain.Messages;
using EuropArt.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Accounts
{
    public class AccountResponse
    {
        public class GetIndexAccount
        {
            public AccountDto.Index User { get; set; }
        }
        public class GetLikes
        {
           public List<int> ArtworkIds { get; set; }
        }
        public class GetConversations
        {
            public List<Conversation> Conversations { get; set; }
        }
    }
}
