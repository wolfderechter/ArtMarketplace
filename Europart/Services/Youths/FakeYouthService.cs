/*using EuropArt.Domain.Youths;
using EuropArt.Services.Artworks;
using EuropArt.Shared.Youths;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EuropArt.Services.Youths
{
    public class FakeYouthService : IYouthService
    {
        private static List<Youth> youthArtworks = FakeDataStore.YouthArtworks;


        public async Task<YouthResponse.GetDetail> GetDetailAsync(YouthRequest.GetDetail request)
        {
            await Task.Delay(100);

            YouthResponse.GetDetail response = new();

            response.YouthArtwork = youthArtworks.Select(x => new YoutArtworkhDto.Detail
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImagePath = x.ImagePath,
            }).SingleOrDefault(x => x.Id == request.YouthId);

            return response;
        }


        public async Task<YouthResponse.GetIndex> GetIndexAsync(YouthRequest.GetIndex request)
        {
            await Task.Delay(100);
            YouthResponse.GetIndex response = new();

            response.YouthArtworks = youthArtworks.Select(x => new YouthDto.Index
            {
                Id = x.Id,
                Name = x.Name,
                ImagePath = x.ImagePath,
            }).ToList();

            return response;
        }

        public List<Youth> GetArtworks()
        {
            return youthArtworks;
        }

    }
}
*/