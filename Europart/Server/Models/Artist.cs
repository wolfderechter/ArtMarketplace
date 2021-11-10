using EuropArt.Shared.Artworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Server.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public IEnumerable<string> ImagePaths { get; set; }
        public IEnumerable<Artwork> Artworks { get; set; }
        public string Biography { get; set; }
        public string Website { get; set; }

        public Artist()
        {

        }
    }
}
