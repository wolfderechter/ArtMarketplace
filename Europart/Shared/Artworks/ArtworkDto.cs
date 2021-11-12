using EuropArt.Shared.Artist;
using System.ComponentModel.DataAnnotations;

namespace EuropArt.Shared.Artworks
{
    public class ArtworkDto
    {
        public class Index
        {
            public int Id { get; set; }
            public ArtistDto.Detail Artist { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string ImagePath { get; set; }
        }

        public class Detail : Index
        {
            public string Description { get; set; }
        }

        public class Create
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }

            //public IEnumerable<string> ImagePaths { get; set; }
            public string ImagePath { get; set; }
            //public ArtistDto.Detail Artist { get; set; }


        }
    }
}
