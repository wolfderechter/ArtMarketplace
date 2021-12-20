using EuropArt.Domain.Artworks;
using EuropArt.Domain.Common;
using EuropArt.Domain.Likes;
using System;
using System.Collections.Generic;

namespace EuropArt.Domain.Artists
{
    public class Artist
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Test { get; set; }
        public string Postalcode { get; set; }
        public string Street { get; set; }
        //public IEnumerable<string> ImagePaths { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Artwork> Artworks { get; set; }
        public List<Like> Likes { get; set; } = new();
        public DateTime DateCreated { get; set; }
        public string Biography { get; set; }
        public string Website { get; set; }
        public string TelephoneNr { get; set; }
        public bool IsVerified { get; set; }
        public string AuthId { get; set; }

        public Artist()
        {

        }

        public Artist(string firstname, string lastname, string country, string city, string postalcode, string street, string imagepath, DateTime dateCreated, string biography, string website, string authid)
        {
            FirstName = firstname;
            LastName = lastname;
            Country = country;
            City = city;
            Postalcode = postalcode;
            Street = street;
            ImagePath = imagepath;
            DateCreated = dateCreated;
            Biography = biography;
            Website = website;
            IsVerified = false;
            AuthId = authid;
        }
    }
}
