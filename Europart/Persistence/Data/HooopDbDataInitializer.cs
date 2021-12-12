using EuropArt.Domain.Artists;
using EuropArt.Domain.Artworks;
using EuropArt.Domain.Common;
using EuropArt.Domain.YouthArtworks;
using EuropArt.Persistence.Data;
using System;
using System.Collections.Generic;

namespace EuropArt.Persistence.Data
{
    public class HooopDataInitializer
    {
        private readonly HooopDbContext _dbContext;

        public HooopDataInitializer(HooopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                Artist artist1 = new Artist("Stef", "Boerjan", "Belgium", "Lokeren", "9160", "Park de Rode Poort 9", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/123.jpg", DateTime.Now, "Dit is de beschrijving van ...", "www.Justine.be");
                Artist artist2 = new Artist("Lander", "Steenput", "Belgium", "Zele", "3800", "Magda Cafmeyerstraat 2", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/124.jpg", DateTime.Now, "Dit is de beschrijving van ...", "www.Lander.be");
                Artist artist3 = new Artist("Alex", "De Cock", "Belgium", "Oudenaarde", "9300", "Paalstraat 3", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/125.jpg", DateTime.Now, "Dit is de beschrijving van ...", "www.Alex.be");
                Artist artist4 = new Artist("Gert", "Meert", "Belgium", "Aalst", "8700", "Pauverleutestraat 6", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/126.jpg", DateTime.Now, "Dit is de beschrijving van ...", "www.Gert.be");

                YouthArtist youthArtist1 = new YouthArtist("Logan", "De Vriend", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/146.jpg", DateTime.Now);
                YouthArtist youthArtist2 = new YouthArtist("Jason", "Smet", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/156.jpg", DateTime.Now);
                YouthArtist youthArtist3 = new YouthArtist("Tuur", "Kwissens","https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/135.jpg", DateTime.Now);
                YouthArtist youthArtist4 = new YouthArtist("Patrik", "Goosens", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/165.jpg", DateTime.Now);

                List<Artist> artists = new List<Artist> { artist1, artist2, artist3, artist2, artist4 };
                List<YouthArtist> youthArtists = new List<YouthArtist> { youthArtist1, youthArtist2, youthArtist3, youthArtist4 };
                _dbContext.Artists.AddRange(artists);
                _dbContext.YouthArtists.AddRange(youthArtists);

                Artwork artwork1 = new Artwork("Emmer", new Money(3M), "dit is een beschrijving", artist2, DateTime.Now.AddHours(-222), "abstract", "sculptures");
                Artwork artwork2 = new Artwork("Zonnebloem", new Money(4M), "dit is een beschrijving", artist2, DateTime.Now.AddHours(-40), "modern", "painting");
                Artwork artwork3 = new Artwork("Boter", new Money(12M), "dit is een beschrijving", artist2, DateTime.Now, "surrealism", "sculptures");
                Artwork artwork4 = new Artwork("Koffielepel", new Money(65M), "dit is een beschrijving", artist3, DateTime.Now.AddHours(-80), "modern", "painting");
                Artwork artwork5 = new Artwork("Tas", new Money(43M), "dit is een beschrijving", artist3, DateTime.Now.AddHours(-200), "abstract", "photography");
                Artwork artwork6 = new Artwork("Hesp", new Money(543M), "dit is een beschrijving", artist3, DateTime.Now.AddHours(-25), "minimalism", "drawings");
                Artwork artwork7 = new Artwork("Kaas", new Money(23M), "dit is een beschrijving", artist6, DateTime.Now.AddHours(-320), "surrealism", "drawings");
                Artwork artwork8 = new Artwork("Auto", new Money(96M), "dit is een beschrijving", artist9, DateTime.Now.AddHours(-430), "modern", "painting");
                Artwork artwork9 = new Artwork("Maan", new Money(58M), "dit is een beschrijving", artist6, DateTime.Now.AddHours(-290), "minimalism", "photography");
                Artwork artwork10 = new Artwork("Feest", new Money(24M), "dit is een beschrijving", artist3, DateTime.Now.AddHours(-180), "abstract", "painting");
                Artwork artwork11 = new Artwork("Tafel", new Money(38M), "dit is een beschrijving", artist8, DateTime.Now.AddHours(-90), "minimalism", "painting");
                Artwork artwork12 = new Artwork("Stoel", new Money(10M), "dit is een beschrijving", artist8, DateTime.Now.AddHours(-60), "surrealism", "photography");
                Artwork artwork13 = new Artwork("Bank", new Money(201M), "dit is een beschrijving", artist8, DateTime.Now.AddHours(-50), "minimalism", "drawings");
                Artwork artwork14 = new Artwork("Vliegtuig", new Money(158M), "dit is een beschrijving", artist14, DateTime.Now.AddHours(-4), "abstract", "drawings");

                YouthArtwork youthArtwork1 = new YouthArtwork("jeugd kunstwerk", "Dit is een jeugdkunstwerk", youthArtist1, DateTime.Now);
                YouthArtwork youthArtwork2 = new YouthArtwork("jeugd kunstwerk", "Dit is een jeugdkunstwerk", youthArtist1, DateTime.Now);
                YouthArtwork youthArtwork3 = new YouthArtwork("jeugd kunstwerk", "Dit is een jeugdkunstwerk", youthArtist1, DateTime.Now);
                YouthArtwork youthArtwork4 = new YouthArtwork("jeugd kunstwerk", "Dit is een jeugdkunstwerk", youthArtist1, DateTime.Now);
                YouthArtwork youthArtwork5 = new YouthArtwork("jeugd kunstwerk", "Dit is een jeugdkunstwerk", youthArtist1, DateTime.Now);
                YouthArtwork youthArtwork6 = new YouthArtwork("jeugd kunstwerk", "Dit is een jeugdkunstwerk", youthArtist1, DateTime.Now);
                YouthArtwork youthArtwork7 = new YouthArtwork("jeugd kunstwerk", "Dit is een jeugdkunstwerk", youthArtist1, DateTime.Now);
                YouthArtwork youthArtwork8 = new YouthArtwork("jeugd kunstwerk", "Dit is een jeugdkunstwerk", youthArtist1, DateTime.Now);
                YouthArtwork youthArtwork9 = new YouthArtwork("jeugd kunstwerk", "Dit is een jeugdkunstwerk", youthArtist1, DateTime.Now);
                YouthArtwork youthArtwork10 = new YouthArtwork("jeugd kunstwerk", "Dit is een jeugdkunstwerk", youthArtist1, DateTime.Now);
                YouthArtwork youthArtwork11 = new YouthArtwork("jeugd kunstwerk", "Dit is een jeugdkunstwerk", youthArtist1, DateTime.Now);

                artwork1.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeartworks/1.jpg";
                artwork2.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeartworks/2.jpg";
                artwork3.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeartworks/3.jpg";
                artwork4.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeartworks/4.jpg";
                artwork5.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeartworks/5.jpg";
                artwork6.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeartworks/6.jpg";
                artwork7.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeartworks/7.jpg";
                artwork8.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeartworks/8.jpg";
                artwork9.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeartworks/9.jpg";
                artwork10.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeartworks/10.jpg";
                artwork11.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeartworks/11.jpg";
                artwork12.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeartworks/12.jpg";
                artwork13.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeartworks/13.jpg";
                artwork14.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeartworks/14.jpg";

                youthArtwork1.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeyouthartworks/1.jpg";
                youthArtwork2.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeyouthartworks/2.jpg";
                youthArtwork3.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeyouthartworks/3.jpg";
                youthArtwork4.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeyouthartworks/4.jpg";
                youthArtwork5.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeyouthartworks/5.jpg";
                youthArtwork6.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeyouthartworks/6.jpg";
                youthArtwork7.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeyouthartworks/7.jpg";
                youthArtwork8.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeyouthartworks/8.jpg";
                youthArtwork9.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeyouthartworks/9.jpg";
                youthArtwork10.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeyouthartworks/10.jpg";
                youthArtwork11.ImagePath = $"https://demostoragehogent.blob.core.windows.net/fakeyouthartworks/11.jpg";
          


                List<Artwork> artworks = new List<Artwork> { artwork1, artwork2, artwork3, artwork4 , artwork5 , artwork6 , artwork7 , artwork8 , artwork9 , artwork10 , artwork11 , artwork12 , artwork13 , artwork14 };

                _dbContext.YouthArtworks.AddRange(youthArtwork1, youthArtwork2, youthArtwork3, youthArtwork4, youthArtwork5, youthArtwork6, youthArtwork7, youthArtwork8, youthArtwork9, youthArtwork10, youthArtwork11);
                _dbContext.Artworks.AddRange(artworks);
                
                _dbContext.SaveChanges();

            }
        }


    }
}