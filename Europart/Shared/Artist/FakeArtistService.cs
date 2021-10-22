using Bogus;
using EuropArt.Shared.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Artist
{
    public class FakeArtistService : IArtistService
    {
        private static List<ArtistDto.Detail> _artists = new();

        static FakeArtistService()
        {
            var artistIds = 0;

            var faker = new Faker<ArtistDto.Detail>("en")
                .RuleFor(x => x.Id, _ => artistIds++)
                .RuleFor(x => x.ImagePath, f => f.Internet.Avatar())
                .RuleFor(x => x.City, f => f.Address.City())
                .RuleFor(x => x.Name, f => f.Name.FullName());

            _artists.AddRange(faker.Generate(25));
        }

        public async Task<ArtistDto.Detail> GetDetailAsync(int id)
        {
            await Task.Delay(100);
            return _artists.SingleOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<ArtistDto.Index>> GetIndexAsync()
        {
            await Task.Delay(100);
            return _artists.AsEnumerable();
        }
    }
}
