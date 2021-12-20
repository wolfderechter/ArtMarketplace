using EuropArt.Domain.Artists;
using EuropArt.Domain.Artworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Domain.Likes
{
    public class Like
    {
        public string AuthId { get; set; }
        public int ArtworkId { get; set; }
        public Artwork Artwork { get; set; }

        public Like()
        {

        }
        public Like(string authId, Artwork artwork)
        {
            AuthId = authId;
            Artwork = artwork;
        }
    }
}
