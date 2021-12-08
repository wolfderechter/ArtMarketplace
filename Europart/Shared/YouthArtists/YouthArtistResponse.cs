using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.YouthArtists
{
    public class YouthArtistResponse
    {
        public class GetIndex
        {
            public List<YouthArtistDto.Index> YouthArtists { get; set; }
            public int TotalAmount { get; set; }
        }

        public class GetDetail
        {
            public YouthArtistDto.Detail Artist { get; set; }
        }

        public class Delete
        {

        }

        public class Edit
        {
            public int YouthArtistId { get; set; }
        }
    }
}
