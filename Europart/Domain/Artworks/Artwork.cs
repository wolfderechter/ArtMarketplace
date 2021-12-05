using Ardalis.GuardClauses;
using EuropArt.Domain.Artists;
using EuropArt.Domain.Common;
using System;

namespace EuropArt.Domain.Artworks
{
    public class Artwork
    {
        public int Id { get; set; }
        public string name;
        public Money price;
        public string category;
        public DateTime DateCreated;
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public string Name { 
            get { return name;  }
            set {  name = Guard.Against.NullOrWhiteSpace(value, nameof(name)); }
        }
        public Money Price {
            get => price;
            set { price = Guard.Against.Null(value, nameof(price)); }
        }
        public string Description { get; set; }
        //public IEnumerable<string> ImagePaths { get; set; }
        public string Style { get; set; }
        public string Category {
            get => category;
            set { category = Guard.Against.Null(value, nameof(category));  }
        }
        public string ImagePath { get; set; }

        public Artwork()
        {

        }

        public Artwork(string name, Money price, string description, DateTime dateCreated)
        {
            Name = name;
            Price = Guard.Against.Null(price, nameof(price));
            Description = description;
            DateCreated = dateCreated;
        }
        public Artwork(string name, Money price, string description, Artist artist, DateTime dateCreated)
        {
            Name = name;
            Price = Guard.Against.Null(price, nameof(price));
            Description = description;
            Artist = artist;
            DateCreated = dateCreated;
        }
    }
}
