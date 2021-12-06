using Ardalis.GuardClauses;
using EuropArt.Domain.Artworks;
using EuropArt.Domain.Common;
using EuropArt.Domain.YouthArtworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Domain.Artists
{
    public class YouthArtist
    {

        public int Id { get; set; }
        public ArtistName Name { get; set; }
        public string Nickname { get; set; }
        public Address Address { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<YouthArtwork> Artworks { get; set; }
        public DateTime DateCreated { get; set; }
        //public bool IsVerified { get; set; }

        public YouthArtist() { }

        public YouthArtist(string firstname, string lastname, string imagePath, DateTime dateCreated)
        {
            Name = new ArtistName(firstname, lastname);
            ImagePath = imagePath;
            DateCreated = dateCreated;
        }
    }
}
