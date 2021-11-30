using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Youths
{
    public class YouthResponse
    {
        public class GetIndex
        {
            public List<YouthDto.Index> YouthArtworks { get; set; } = new();
            public int TotalAmount { get; set; }
        }

        public class GetDetail
        {
            public YouthDto.Detail YouthArtwork  { get; set; }
        }
    }
}
