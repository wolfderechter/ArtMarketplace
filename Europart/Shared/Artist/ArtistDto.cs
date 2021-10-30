using EuropArt.Shared.Artworks;
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
            public IEnumerable<ArtworkDto.Detail> Artworks = Enumerable.Empty<ArtworkDto.Detail>();
        }

        public class Detail : Index
        {
            public string Biography { get; set; }
            public string Website { get; set; }
        }
    }
}
