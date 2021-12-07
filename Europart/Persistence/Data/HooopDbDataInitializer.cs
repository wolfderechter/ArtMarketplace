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

                Artwork artwork1 = new Artwork("kunstwerkje", new Money(3M), "dit is een test", artist2, DateTime.Now);
                Artwork artwork2 = new Artwork("Test1", new Money(4M), "dit is een test", artist3, DateTime.Now);
                Artwork artwork3 = new Artwork("Test2", new Money(30M), "dit is een test", artist3, DateTime.Now);

                YouthArtwork youthArtwork1 = new YouthArtwork("jeugd kunstwerk", "Dit is een jeugdkunstwerk", youthArtist1, DateTime.Now);

                artwork1.ImagePath = $"/images/artworks/1.jpg";
                artwork2.ImagePath = $"/images/artworks/2.jpg";
                artwork3.ImagePath = $"/images/artworks/3.jpg";
                youthArtwork1.ImagePath = $"/images/artworks/1.jpg";

                List<Artwork> artworks = new List<Artwork> { artwork1, artwork2, artwork3};

                _dbContext.YouthArtworks.Add(youthArtwork1);
                _dbContext.Artworks.AddRange(artworks);
                
                _dbContext.SaveChanges();

            }
        }


    }
}