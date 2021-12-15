using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.YouthArtworks
{
    public class YouthArtworkDto
    {
       
            public class Index
            {
                public int Id { get; set; }
                //      public int ArtistId { get; set; }
                public string Name { get; set; }
                public string ImagePath { get; set; }
            }

            public class Detail : Index
            {
                public string Description { get; set; }
            }
        
    }
}
