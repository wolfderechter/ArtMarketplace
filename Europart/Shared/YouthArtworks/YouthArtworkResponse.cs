using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.YouthArtworks
{
    public class YouthArtworkResponse
    {
        public class GetIndex
        {
            public List<YouthArtworkDto.Index> YouthArtworks { get; set; } = new();
            public int TotalAmount { get; set; }
        }

        public class GetDetail
        {
            public YouthArtworkDto.Detail YouthArtwork { get; set; }
        }
    }
}
