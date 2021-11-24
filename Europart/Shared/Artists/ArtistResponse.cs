using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Artists
{
    public class ArtistResponse
    {
        public class GetIndex
        {
            public List<ArtistDto.Index> Artists { get; set; }
            public int TotalAmount { get; set; }
        }

        public class GetDetail
        {
            public ArtistDto.Detail Artist { get; set; }
        }

        public class Delete
        {

        }

        public class Edit
        {
            public int ArtistId { get; set; }
        }
    }
}
