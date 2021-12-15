using FluentValidation;

namespace EuropArt.Shared.YouthArtists
{
    public class YouthArtistRequest
    {
        public class GetIndex
        {
            public string Searchterm { get; set; }
            public int Amount { get; set; } = 25;
            public int Page { get; set; } = 0;
        }

        public class GetDetail
        {
            public int YouthArtistId { get; set; }
        }

        public class Delete
        {
            public int YouthArtistId { get; set; }
        }

        public class Edit
        {
            public int YouthArtistId { get; set; }
            public YouthArtistDto.Edit YouthArtist { get; set; }

            public class Validator : AbstractValidator<Edit>
            {
                public Validator()
                {
                    RuleFor(x => x.YouthArtistId).NotEmpty();
                }
            }
        }
    }
}
