﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.AuthUsers
{
    public static class AuthUserDto
    {
        public class Index
        {
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool Blocked { get; set; }
        }
    }
}
