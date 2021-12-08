using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.YouthArtworks
{
    public class YouthArtworkRequest
    {
        public class GetIndex
        {

        }

        public class GetDetail
        {
            public int YouthArtworkId { get; set; }
        }
    }
}
