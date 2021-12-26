using EuropArt.Domain.Artists;
using EuropArt.Domain.Common;
using EuropArt.Domain.Likes;
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
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string ImagePath { get; set; }
            public int AmountOfArtworks { get; set; }
            public string Email { get; set; }
            public string Postalcode { get; set; }
            public DateTime DateCreated { get; set; }
            public List<Like> Likes { get; set; }
        }

        public class Detail : Index
        {
            public string Country { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public string Biography { get; set; }
            public string Website { get; set; }
            public List<ArtworkDto.Detail> Artworks { get; set; } = new();
            public string AuthId { get; set; }
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
            public string ImagePath { get; set; }

            public DateTime DateCreated { get; set; }
            public string AuthId { get; set; }
            public class ArtistValidator : AbstractValidator<Create>
            {
                public ArtistValidator(IStringLocalizer<Resources.Artists.Edit> Loc)
                {
                    RuleFor(P => P.FirstName).NotEmpty().WithMessage(Loc["LastNameError"]);
                    RuleFor(P => P.LastName).NotEmpty().WithMessage(Loc["FirstNameError"]);
                    RuleFor(p => p.Country).NotEmpty().WithMessage(Loc["CountryError"]);
                    RuleFor(p => p.City).NotEmpty().WithMessage(Loc["CityError"]);
                    RuleFor(p => p.PostalCode).NotEmpty().WithMessage(Loc["PostalcodeError"]);
                    RuleFor(p => p.Street).NotEmpty().WithMessage(Loc["StreetError"]);
                    RuleFor(p => p.Nickname).NotEmpty().WithMessage(Loc["NicknameError"]);
                    RuleFor(p => p.TelephoneNr).NotEmpty().WithMessage(Loc["TelephoneNrError"]);
                    
                }
            }
        }

        public class Edit
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            //address
            public string Country { get; set; }
            public string City { get; set; }
            public string Postalcode { get; set; }
            public string Street { get; set; }
            public string Biography { get; set; }
            public string Website { get; set; }
            public string AuthId { get; set; }
            public string ImagePath { get; set; }
            public class ArtistValidator : AbstractValidator<Edit>
            {
                public ArtistValidator(IStringLocalizer<Resources.Artists.Edit> Loc)
                {
                    RuleFor(P => P.FirstName).NotEmpty().WithMessage(Loc["FirstNameError"]);
                    RuleFor(P => P.LastName).NotEmpty().WithMessage(Loc["LastNameError"]);
                    RuleFor(p => p.Country).NotEmpty().WithMessage(Loc["CountryError"]);
                    RuleFor(p => p.City).NotEmpty().WithMessage(Loc["CityError"]);
                    RuleFor(p => p.Postalcode).NotEmpty().WithMessage(Loc["PostalcodeError"]);
                    RuleFor(p => p.Street).NotEmpty().WithMessage(Loc["StreetError"]);
                    RuleFor(p => p.AuthId).NotEmpty().WithMessage(Loc["AuthId"]);
                }
            }

        }
    }
}
