using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Europart.Models.Domain
{
    public class Artist : User
    {
        public string Fields { get;}
        public string ArtistName { get; }
        public Subscription Subscription { get; }

        public List<Artwork> Artworks = new List<Artwork>();





    }
}
