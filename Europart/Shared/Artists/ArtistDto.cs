using EuropArt.Domain.Artists;
using EuropArt.Domain.Common;
using EuropArt.Shared.Artworks;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;

namespace EuropArt.Shared.Artists
{
    public static class ArtistDto
    {
        public class Index
        {
            public int Id { get; set; }
            public ArtistName Name { get; set; }
            public Address Address { get; set; }
            public string ImagePath { get; set; }
            public int AmountOfArtworks { get; set; }
            public string Email { get; set; }
            public DateTime DateCreated { get; set; }
        }

        public class Detail : Index
        {
            public string Biography { get; set; }
            public string Website { get; set; }
            public List<ArtworkDto.Detail> Artworks { get; set; } = new();
        }

        public class Create
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Country { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string PostalCode { get; set; }
            public string Nickname { get; set; }
            public string Biography { get; set; }
            public string Website { get; set; }
            public string TelephoneNr { get; set; }
        }

        public class Edit
        {
            public ArtistName Name { get; set; }
            public Address Address { get; set; }
            public string Biography { get; set; }
            public string Website { get; set; }
            public class ArtistValidator : AbstractValidator<ArtistDto.Edit>
            {
                public ArtistValidator(IStringLocalizer<Resources.Artists.Edit> Loc)
                {
                    RuleFor(P => P.Name).NotEmpty().WithMessage(Loc["NameError"]);
                    RuleFor(p => p.Address).NotEmpty().WithMessage(Loc["CityError"]);
                }
            }
        }
    }
}
