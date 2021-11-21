using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Server.Models
{
    public class Artwork
    {
        public int Id { get; set; }
        public Artist Artist { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> ImagePaths { get; set; }

        private Artwork()
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
