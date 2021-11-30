using Ardalis.GuardClauses;
using EuropArt.Domain.Artists;
using EuropArt.Domain.Common;

namespace EuropArt.Domain.Artworks
{
    public class Artwork
    {

        public string name;
        public Money price;
        public string category;
        public int Id { get; set; }
        public Artist Artist { get; set; }
      
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

        public Artwork(string name, Money price, string description)
        {
            Name = name;
            Price = Guard.Against.Null(price, nameof(price));
            Description = description;
        }
    }
}
