using EuropArt.Domain.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Accounts
{
    public class AccountDto
    {
        public class Index
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string AuthId { get; set; }
            public DateTime DateCreated { get; set; }
            public List<Like> Likes { get; set; }
        }

        public class CreateMessage
        {
            public string Content { get; set; }
            public DateTime DateCreated { get; set; }
            public string AuthId { get; set; }
            public int ConversationId { get; set; }
        }

        public class Create
        {
        }
    }
}
