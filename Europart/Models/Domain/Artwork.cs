using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Europart.Models.Domain
{
    public class Artwork
    {
        public string Title{ get;}
        public ArtType ArtType { get; }
        public bool Sold { get;  }
        public DateTime DateTime { get;}
        public Description Description { get; set; }


    }
}
