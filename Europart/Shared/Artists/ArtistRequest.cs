using EuropArt.Shared.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Artists
{
    public class ArtistRequest
    {
        public class GetIndex
        {
            public string Searchterm { get; set; }
            public OrderByArtist? OrderBy { get; set; }
        }

        public class GetDetail
        {
            public int ArtistId { get; set; }
        }

        public class Delete
        {
            public int ArtistId { get; set; }
        }

        public class Edit
        {
            public int ArtistId { get; set; }
            public ArtistDto.Edit Artist { get; set; }

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
