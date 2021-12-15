using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.YouthArtists
{
    public interface IYouthArtistService
    {
        Task<YouthArtistResponse.GetIndex> GetIndexAsync(YouthArtistRequest.GetIndex request);
        Task<YouthArtistResponse.GetDetail> GetDetailAsync(YouthArtistRequest.GetDetail request);
        Task<YouthArtistResponse.Edit> EditAsync(YouthArtistRequest.Edit request);
        Task DeleteAsync(YouthArtistRequest.Delete request);

    }
}
