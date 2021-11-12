using Bogus;
using EuropArt.Shared.Artist;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropArt.Shared.Artworks
{
    public class FakeArtworkService : IArtworkService
    {
        private static List<ArtworkDto.Detail> artworks = new();

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
                .RuleFor(x => x.ImagePath, _ => $"/images/artworks/{artworkIds}.jpg");

            artworks.AddRange(faker.Generate(29));
        }

        public async Task<ArtworkDto.Detail> GetDetailAsync(int id)
        {
            await Task.Delay(100);
            return artworks.SingleOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<ArtworkDto.Index>> GetIndexAsync()
        {
            await Task.Delay(100);
            return artworks.AsEnumerable();
        }

        //Temporary for faker
        public IEnumerable<ArtworkDto.Detail> GetArtworks()
        {
            return artworks;
        }

        public async Task CreateAsync(ArtworkDto.Create model)
        {
            await Task.Delay(100);
            //var a = new Artwork(model.Name, model.Price, model.Description);
            //api call doen

            //MOCK
            var artistFaker = new FakeArtistService();
            var artists = artistFaker.GetArtists();

            var mappedArtwork = new ArtworkDto.Detail
            {
                Id = artworks.Max(x => x.Id) + 1, //fake id
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                //MOCK
                ImagePath = "/images/artworks/1.jpg",
                Artist = artists.First()
            };
            
            artworks.Add(mappedArtwork);
            //return model.Id;
        }

        public Task DeleteAsync(int id)
        {
            var a = artworks.SingleOrDefault(x => x.Id == id);
            artworks.Remove(a);
            return Task.CompletedTask;
        }
    }
}
