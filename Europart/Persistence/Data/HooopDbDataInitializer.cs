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
                Artist artist5 = new Artist("Jef", "Van Der Coelden", "Belgium", "Namen", "3930", "Pater Verbieststraat 3", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/127.jpg", DateTime.Now, "Dit is de beschrijving van ...", "www.Jef.be");
                Artist artist6 = new Artist("Casper", "De Vos", "Belgium", "Luik", "9051", "Pestelstraat 10", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/128.jpg", DateTime.Now, "Dit is de beschrijving van ...", "www.Casper.be");
                Artist artist7 = new Artist("Hans", "De Pauw", "Belgium", "Hasselt", "1105", "Park de Rode Poort 14", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/129.jpg", DateTime.Now, "Dit is de beschrijving van ...", "www.Hans.be");
                Artist artist8 = new Artist("Melissa", "Van Lierde", "Belgium", "Daknam", "9051", "Maalderijstraat 55", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/133.jpg", DateTime.Now, "Dit is de beschrijving van ...", "www.Melissa.be");
                Artist artist9 = new Artist("Nadja", "Van Den Borre", "Belgium", "Diest", "1105", "Paalstraat 67", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/143.jpg", DateTime.Now, "Dit is de beschrijving van ...", "www.Nadja.be");
                Artist artist10 = new Artist("Amandine", "Raes", "Belgium", "Eeklo", "9160", "Magda Cafmeyerstraat 43", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/153.jpg", DateTime.Now, "Dit is de beschrijving van ...", "www.Amandine.be");
                Artist artist11 = new Artist("Evi", "De Wever", "Belgium", "Gent", "9000", "Pannebekestraat 9", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/163.jpg", DateTime.Now, "Dit is de beschrijving van ...", "www.Evi.be");
                Artist artist12 = new Artist("Dylan", "De Vlaemick", "Belgium", "Gent", "9000", "Maalderijstraat 5", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/173.jpg", DateTime.Now, "Dit is de beschrijving van ...", "www.Dylan.be");
                Artist artist13 = new Artist("Kim", "Noppe", "Belgium", "Ieper", "1105", "Park de Rode Poort 97", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/183.jpg", DateTime.Now, "Dit is de beschrijving van ...", "www.Kim.be");
                Artist artist15 = new Artist("Joke", "De Winter", "Belgium", "Kortrijk", "9051", "Pannebekestraat 93", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/193.jpg", DateTime.Now, "Dit is de beschrijving van ...", "www.Joke.be");
                Artist artist16 = new Artist("Tanja", "Van Daele", "Belgium", "Gent", "9000", "Maalderijstraat 5", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/123.jpg", DateTime.Now, "Dit is de beschrijving van ...", "www.Tanja.be");
                Artist artist14 = new Artist("Erik", "Peeters", "Belgium", "Leuven", "9051", "Park de Rode Poort 44", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/223.jpg", DateTime.Now, "Dit is de beschrijving van ...", "www.Erik.be");
                Artist artist17 = new Artist("Lotte", "De Ridder", "Belgium", "Gent", "9000", "Maalderijstraat 55", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/224.jpg", DateTime.Now, "Dit is de beschrijving van ...", "www.Lotte.be");
                Artist artist18 = new Artist("Daan", "Verschuere", "Belgium", "Limburg", "8211", "Paalstraat 24", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/134.jpg", DateTime.Now, "Dit is de beschrijving van ...", "www.Daan.be");
                Artist artist19 = new Artist("Arne", "Van Langenhove", "Belgium", "Oostende", "4557", "Magda Cafmeyerstraat 56", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/143.jpg", DateTime.Now, "Dit is de beschrijving van ...", "www.Arne.be");

                YouthArtist youthArtist1 = new YouthArtist("Logan", "De Vriend", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/146.jpg", DateTime.Now);
                YouthArtist youthArtist2 = new YouthArtist("Jason", "Smet", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/156.jpg", DateTime.Now);
                YouthArtist youthArtist3 = new YouthArtist("Tuur", "Kwissens","https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/135.jpg", DateTime.Now);
                YouthArtist youthArtist4 = new YouthArtist("Patrik", "Goosens", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/165.jpg", DateTime.Now);
                YouthArtist youthArtist5 = new YouthArtist("Sander", "Pauwels", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/176.jpg", DateTime.Now);
                YouthArtist youthArtist6 = new YouthArtist("Benny", "Dobbelaer", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/188.jpg", DateTime.Now);
                YouthArtist youthArtist7 = new YouthArtist("Xeno", "Verzele", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/156.jpg", DateTime.Now);
                YouthArtist youthArtist8 = new YouthArtist("Johan", "De Bakker", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/176.jpg", DateTime.Now);
                YouthArtist youthArtist9 = new YouthArtist("Leonie", "Van Steenkiste", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/154.jpg", DateTime.Now);
                YouthArtist youthArtist10 = new YouthArtist("Jolien", "Koppes", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/157.jpg", DateTime.Now);
                YouthArtist youthArtist11 = new YouthArtist("Axelle", "Tersago", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/176.jpg", DateTime.Now);
                YouthArtist youthArtist12 = new YouthArtist("Kato", "De Rechter", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/187.jpg", DateTime.Now);
                YouthArtist youthArtist13 = new YouthArtist("Zowie", "Wauters", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/189.jpg", DateTime.Now);

                List<Artist> artists = new List<Artist> { artist1, artist2, artist3, artist2, artist4, artist5, artist6, artist7, artist8, artist9, artist10, artist11, artist12, artist12, artist13, artist14, artist15, artist16, artist17, artist18, artist19 };
                List<YouthArtist> youthArtists = new List<YouthArtist> { youthArtist1, youthArtist2, youthArtist3, youthArtist4, youthArtist5, youthArtist6, youthArtist7, youthArtist8, youthArtist9, youthArtist10, youthArtist11, youthArtist12, youthArtist13 };
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