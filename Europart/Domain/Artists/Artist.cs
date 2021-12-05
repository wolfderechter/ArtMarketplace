using Ardalis.GuardClauses;
using EuropArt.Domain.Artworks;
using System;
using System.Collections.Generic;

namespace EuropArt.Domain.Artists
{
    public class Artist
    {
        private string name;
        private string city;
        public int Id { get; set; }
        public string Name { 
            get { return name; }
            set { name = Guard.Against.NullOrWhiteSpace(value, nameof(name)); }
        }
        public string City { 
            get { return city;  }
            set { city = Guard.Against.NullOrWhiteSpace(value, nameof(city));  }
        }

        //public IEnumerable<string> ImagePaths { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<Artwork> Artworks { get; set; }
        public string Biography { get; set; }
        public string Website { get; set; }
        public DateTime DateCreated { get; set; }

        public Artist()
        {

        }

        public Artist(string name , string city, string biography, string website, string imagepath, DateTime dateCreated)
        {
            Name = name;
            City = city;
            Biography = biography;
            Website = website;
            ImagePath = imagepath;
            DateCreated = dateCreated;
        }

    }
}
