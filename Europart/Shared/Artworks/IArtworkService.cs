using System.Collections.Generic;
using System.Threading.Tasks; 
namespace EuropArt.Shared.Artworks
{
    public interface IArtworkService
    {
        Task<IEnumerable<ArtworkDto.Index>> GetIndexAsync();
        Task<ArtworkDto.Detail> GetDetailAsync(int id);
        Task CreateAsync(ArtworkDto.Create model);
        Task DeleteAsync(int id);
    }
}
