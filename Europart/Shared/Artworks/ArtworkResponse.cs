using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Artworks
{
    public static class ArtworkResponse
    {
        public class GetIndex
        {
            public List<ArtworkDto.Index> Artworks { get; set; } = new();
            public int TotalAmount { get; set; }
        }

        public class GetDetail
        {
            public ArtworkDto.Detail Artwork { get; set; }
        }

        public class Delete
        {

        }

        public class Create
        {
            public int ArtworkId { get; set; }
            public Uri UploadUri { get; set; }
        }

        public class Edit
        {
            public int ArtworkId { get; set; }
        }
    }
}
