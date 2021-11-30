using EuropArt.Shared.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Artworks
{
    public static class ArtworkRequest
    {
        public class GetIndex
        {
            public string Searchterm { get; set; }
            public string Category { get; set; }
            public decimal? MinimumPrice { get; set; }
            public decimal? MaximumPrice { get; set; }
            public bool IncludingAuctions { get; set; }
            public string Style { get; set; }
            public OrderByArtwork? OrderBy { get; set; }
            public int Amount { get; set; } = 25;
            public int Page { get; set; } = 0;
        }

        public class GetDetail
        {
            public int ArtworkId { get; set; }
        }

        public class Delete
        {
            public int ArtworkId { get; set; }
        }

        public class Create
        {
            public ArtworkDto.Create Artwork { get; set; }
        }

        public class Edit
        {
            public int ArtworkId { get; set; }
            public ArtworkDto.Edit Artwork { get; set; }

            public class Validator : AbstractValidator<Edit>
            {
                public Validator()
                {
                    RuleFor(x => x.ArtworkId).NotEmpty();
                }
            }
        }
    }
}
