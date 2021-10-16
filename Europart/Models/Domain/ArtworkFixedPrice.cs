using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Europart.Models.Domain
{
    public class ArtworkFixedPrice : Artwork
    {
        public decimal Price { get; set; }
    }
}
