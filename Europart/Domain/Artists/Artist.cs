using EuropArt.Domain.Artworks;
using System.Collections.Generic;

namespace EuropArt.Domain.Artists
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        //public IEnumerable<string> ImagePaths { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<Artwork> Artworks { get; set; }
        public string Biography { get; set; }
        public string Website { get; set; }

        public Artist()
        {

        }


    }
}
