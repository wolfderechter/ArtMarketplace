using EuropArt.Domain.Artists;
using EuropArt.Shared.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Artists
{
    public interface IArtistService
    {
        Task<ArtistResponse.GetIndex> GetIndexAsync(ArtistRequest.GetIndex request);
        Task<ArtistResponse.GetDetail> GetDetailAsync(ArtistRequest.GetDetail request);
        Task<ArtistResponse.Edit> EditAsync(ArtistRequest.Edit request);
        Task DeleteAsync(ArtistRequest.Delete request);
        Task<ArtistResponse.Create> CreateAsync(ArtistRequest.Create request);
        //only used for android
        Task<List<ArtistDto.Detail>> GetArtistsAndroidAsync(ArtistRequest.GetIndex request);
    }
}
