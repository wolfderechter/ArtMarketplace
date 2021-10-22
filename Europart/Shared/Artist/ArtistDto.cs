using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Artist
{
    public static class ArtistDto
    {
        public class Index
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string City { get; set; }
            public string ImagePath { get; set; }
        }

        public class Detail : Index
        {

        }
    }
}
