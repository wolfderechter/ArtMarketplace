using System.Collections.Generic;
using System.Threading.Tasks; 
namespace EuropArt.Shared.Artworks
{
    public interface IArtworkService
    {
        Task<IEnumerable<ArtworkDto.Index>> GetIndexAsync();
        Task<IEnumerable<ArtworkDto.Index>> GetIndexAsync(string searchterm);
        Task<ArtworkDto.Detail> GetDetailAsync(int id);
        Task CreateAsync(ArtworkDto.Create model);
        Task DeleteAsync(int id);
        Task DeleteArtistAsync(int id);
        Task UpdateAsync(ArtworkDto.Detail model, int id); 
    }
}
