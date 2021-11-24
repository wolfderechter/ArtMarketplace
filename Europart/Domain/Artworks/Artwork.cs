using EuropArt.Domain.Artists;

namespace EuropArt.Domain.Artworks
{
    public class Artwork
    {
        public int Id { get; set; }
        public Artist Artist { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        //public IEnumerable<string> ImagePaths { get; set; }
        public string ImagePath { get; set; }

        public Artwork()
        {

        }

        public Artwork(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }
    }
}
