using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Users
{
    public class UserResponse
    {
        public class GetIndex
        {
            public UserDto.Index User { get; set; }
        }
        public class Create
        {
            public int UserId { get; set; }
        }
    }
}
