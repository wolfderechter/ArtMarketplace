using EuropArt.Shared.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Artist
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistDto.Index>> GetIndexAsync();
        Task<IEnumerable<ArtistDto.Index>> GetIndexAsync(string searchterm);
        Task<ArtistDto.Detail> GetDetailAsync(int id);
        Task UpdateArtistAsync(ArtistDto.Edit model, int id);
        Task DeleteAsync(int id);


    }
}
