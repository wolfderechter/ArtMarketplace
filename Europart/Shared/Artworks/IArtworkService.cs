using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Artworks
{
    public interface IArtworkService
    {
        Task<IEnumerable<ArtworkDto.Index>> GetIndexAsync();
        Task<ArtworkDto.Detail> GetDetailAsync(int id);

    }
}
