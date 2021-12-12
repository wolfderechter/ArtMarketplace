using EuropArt.Domain.Artworks;
using EuropArt.Domain.Common;
using System;
using System.Collections.Generic;

namespace EuropArt.Domain.Artists
{
    public class Artist
    {
        public int Id { get; set; }
        public ArtistName Name { get; set; }
        public string Nickname { get; set; }
        public Address Address { get; set; }
        //public IEnumerable<string> ImagePaths { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<Artwork> Artworks { get; set; }
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
            Name = new ArtistName(firstname, lastname);
            Address = new Address(country, city, postalcode, street);
            ImagePath = imagepath;
            DateCreated = dateCreated;
            Biography = biography;
            Website = website;
            IsVerified = false;
            AuthId = authid;
        }
    }
}
