using EuropArt.Domain.Likes;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Users
{
    public class UserDto
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
        public class Create
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string AuthId { get; set; }
            public DateTime DateCreated { get; set; }
        }
        public class Edit
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public class ArtistValidator : AbstractValidator<Edit>
            {
                public ArtistValidator(IStringLocalizer<Resources.Artists.Edit> Loc)
                {
                    RuleFor(P => P.FirstName).NotEmpty().WithMessage(Loc["LastNameError"]);
                    RuleFor(P => P.LastName).NotEmpty().WithMessage(Loc["FirstNameError"]);
                }
            }

        }
    }
}
