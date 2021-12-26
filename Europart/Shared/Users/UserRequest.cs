using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Users
{
    public class UserRequest
    {
        public class Create
        {
            public UserDto.Create User { get; set; }
        }

        public class GetIndex
        {
            public string AuthId { get; set; }
        }

        public class Edit
        {
            public int ArtistId { get; set; }
            public UserDto.Edit Artist { get; set; }

            public class Validator : AbstractValidator<Edit>
            {
                public Validator()
                {
                    RuleFor(x => x.ArtistId).NotEmpty();
                }
            }
        }
    }
}
