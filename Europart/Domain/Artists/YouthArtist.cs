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
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Nickname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Postalcode { get; set; }
        public string Street { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<YouthArtwork> Artworks { get; set; }
        public DateTime DateCreated { get; set; }
        //public bool IsVerified { get; set; }

        public YouthArtist() { }

        public YouthArtist(string firstname, string lastname, string imagePath, DateTime dateCreated)
        {
            FirstName = firstname;
            LastName = lastname;
            ImagePath = imagePath;
            DateCreated = dateCreated;
            //Country = country;
            //City = city;
            //Postalcode = postalcode;
            //Street = street;
        }
    }
}
