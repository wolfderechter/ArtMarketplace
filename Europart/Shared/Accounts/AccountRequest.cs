﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Accounts
{
    public class AccountRequest
    {

        public class AddLike
        {
            public string AuthId { get; set; }
            public int ArtworkId { get; set; }
        }

        public class GetLikes
        {
     //       public string Role { get; set; }
            public string AuthId { get; set; }
        }
    }
}
