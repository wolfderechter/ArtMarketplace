using Bogus;
using EuropArt.Shared.Artist;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropArt.Shared.Artworks
{
    public class FakeArtworkService : IArtworkService
    {
        private static List<ArtworkDto.Detail> _artworks = new();

        static FakeArtworkService()
        {
            var artworkIds = 0;
            var artistFaker = new FakeArtistService();
            var artists = artistFaker.GetArtists();

            var faker = new Faker<ArtworkDto.Detail>("en")
                .RuleFor(x => x.Id, _ => artworkIds++)
                .RuleFor(x => x.Name, f => f.Commerce.ProductName())
                //Name en Id van een Artist is enige belangrijke
                .RuleFor(x => x.Artist, f => f.PickRandom(artists))
                .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
                .RuleFor(x => x.Price, f => f.Random.Decimal(0, 250))
                .RuleFor(x => x.ImagePath, f => f.Internet.Avatar());

            _artworks.AddRange(faker.Generate(250));
        }

        public async Task<ArtworkDto.Detail> GetDetailAsync(int id)
        {
            await Task.Delay(100);
            return _artworks.SingleOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<ArtworkDto.Index>> GetIndexAsync()
        {
            await Task.Delay(100);
            return _artworks.AsEnumerable();
        }

        public IEnumerable<ArtworkDto.Detail> GetArtworks()
        {
            return _artworks;
        }
    }
}
