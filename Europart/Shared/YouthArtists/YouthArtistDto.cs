using EuropArt.Domain.Artists;
using EuropArt.Domain.Common;
using EuropArt.Shared.YouthArtworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.YouthArtists
{
    public class YouthArtistDto
    {
        public class Index
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Address Address { get; set; }
            public string ImagePath { get; set; }
            public DateTime DateCreated { get; set; }
            public int AmountOfArtworks { get; set; }
        }

        public class Detail : Index
        {
            public List<YouthArtworkDto.Detail> Artworks { get; set; } = new();
        }

        public class Edit
        {

        }


    }

   
}
