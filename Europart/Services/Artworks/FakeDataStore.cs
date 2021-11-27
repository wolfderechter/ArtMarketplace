using Bogus;
using EuropArt.Domain.Artists;
using EuropArt.Domain.Artworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Services.Artworks
{
    public static  class FakeDataStore
    {
        public static List<Artwork> Artworks = new();
        public static List<Artist> Artists = new();
        static FakeDataStore()
        {
            var artistIds = 0;
            var testArtists = new Faker<Artist>()
                .RuleFor(x => x.Id, f => artistIds++)
                .RuleFor(u => u.Name, (f, u) => f.Name.FirstName())
                .RuleFor(u => u.ImagePath, f => f.Internet.Avatar());

            Artists = testArtists.Generate(10);

            var artworkIds = 0;
            var testArtworks = new Faker<Artwork>()
                .RuleFor(o => o.Id, f => artworkIds++)
                .RuleFor(x => x.Name, f => f.Commerce.ProductName())
                .RuleFor(x => x.Artist, f => f.PickRandom(Artists))
                .RuleFor(x => x.ImagePath, _ => $"/images/artworks/{artworkIds}.jpg");


            Artworks = testArtworks.Generate(10);
        }
    }
}
