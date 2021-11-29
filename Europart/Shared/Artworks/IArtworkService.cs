using System.Collections.Generic;
using System.Threading.Tasks; 
namespace EuropArt.Shared.Artworks
{
    public interface IArtworkService
    {
        //Task<IEnumerable<ArtworkDto.Index>> GetIndexAsync();
        //Task<IEnumerable<ArtworkDto.Index>> GetIndexAsync(string searchterm);
        //Task<ArtworkDto.Detail> GetDetailAsync(int id);
        //Task CreateAsync(ArtworkDto.Create model);
        //Task DeleteAsync(int id);
        //Task DeleteArtistAsync(int id);
        //Task UpdateAsync(ArtworkDto.Edit model, int id); 

        Task<ArtworkResponse.GetIndex> GetIndexAsync(ArtworkRequest.GetIndex request);
        Task<ArtworkResponse.GetDetail> GetDetailAsync(ArtworkRequest.GetDetail request);
        Task<ArtworkResponse.Create> CreateAsync(ArtworkRequest.Create request);
        Task DeleteAsync(ArtworkRequest.Delete request);
        Task DeleteArtistAsync(int id);
        Task<ArtworkResponse.Edit> EditAsync(ArtworkRequest.Edit request);
    }
}
