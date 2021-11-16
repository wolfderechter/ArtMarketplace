using EuropArt.Shared.Artworks;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Artist
{
    public static class ArtistDto
    {
        public class Index
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string City { get; set; }
            public string ImagePath { get; set; }

            public IEnumerable<ArtworkDto.Detail> Artworks = new List<ArtworkDto.Detail>();
        }

        public class Detail : Index
        {
            public string Biography { get; set; }
            public string Website { get; set; }
        }

        public class Edit
        {
            public string Name { get; set; }
            public string City { get; set; }
            public string Biography { get; set; }
            public string Website { get; set; }
            public class ArtistValidator : AbstractValidator<ArtistDto.Detail>
            {
                public ArtistValidator(IStringLocalizer<Resources.Artists.Edit> Loc)
                {
                    RuleFor(P => P.Name).NotEmpty().WithMessage(Loc["NameError"]);
                    RuleFor(p => p.City).NotEmpty().WithMessage(Loc["CityError"]);


                }
            }
        }
    }
}
