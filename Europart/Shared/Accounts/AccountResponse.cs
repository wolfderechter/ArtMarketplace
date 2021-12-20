using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Accounts
{
    public class AccountResponse
    {
        public class GetLikes
        {
           public List<int> ArtworkIds { get; set; }
        }
    }
}
