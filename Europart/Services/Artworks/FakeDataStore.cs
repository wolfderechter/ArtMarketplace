using Bogus;
using EuropArt.Domain.Artists;
using EuropArt.Domain.Artworks;
using System.Collections.Generic;
using EuropArt.Domain.Youths;
using EuropArt.Domain.Common;

namespace EuropArt.Services.Artworks
{
    public static class FakeDataStore
    {
        public static List<Artwork> Artworks = new();
        public static List<Artist> Artists = new();
        public static List<Youth> YouthArtworks = new();
        static FakeDataStore()
        {
            var artistIds = 0;
            var testArtists = new Faker<Artist>()
                .RuleFor(x => x.Id, f => artistIds++)
                .RuleFor(u => u.Name, (f, u) => f.Name.FirstName())
                .RuleFor(u => u.ImagePath, f => f.Internet.Avatar());

            Artists = testArtists.Generate(50);

            //fake style en category
            List<string> styles = new List<string>() { "modern", "classic", "other" };
            List<string> categories = new List<string>() { "painting", "sculpture", "other" };

            var artworkIds = 0;
            var testArtworks = new Faker<Artwork>()
                .RuleFor(o => o.Id, f => artworkIds++)
                .RuleFor(x => x.Name, f => f.Commerce.ProductName())
                .RuleFor(x => x.Artist, f => f.PickRandom(Artists))
                .RuleFor(x => x.Style, f => f.PickRandom(styles))
                .RuleFor(x => x.Category, f => f.PickRandom(categories))
                .RuleFor(x => x.ImagePath, _ => $"/images/artworks/{artworkIds}.jpg")
                .RuleFor(x => x.Price, f => new Money(f.Random.Decimal(0, 200)));

            Artworks = testArtworks.Generate(75);

            var youthIds = 0;
            var testYouth = new Faker<Youth>()
                .RuleFor(z => z.Id, f => youthIds++)
                .RuleFor(y => y.Name, f => f.Commerce.ProductName())
                .RuleFor(y => y.ImagePath, _ => $"/images/youths/{youthIds}.jpg");

            YouthArtworks = testYouth.Generate(50);
        }
    }
}
