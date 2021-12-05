using EuropArt.Domain.Artists;
using EuropArt.Domain.Artworks;
using EuropArt.Domain.Common;
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
                Artist artist1 = new Artist("Stef Boerjann", "Lokeren", "Nietsnut", "www.ikkanniets.be", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/123.jpg", DateTime.Now);
               /* Artist artist2 = new Artist("Dylan", "Zele", "Ik doe niks", "www.ikhebschijtaanalles.be", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/234.jpg", DateTime.Now);
                Artist artist3 = new Artist("Zowie Verschuere", "Gent", "Baas", "www.ikbendebeste.be", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/666.jpg", DateTime.Now); */
                List<Artist> artists = new List<Artist> { artist1/*, artist2, artist3*/ };
                _dbContext.Artists.AddRange(artists);
                Artwork artwork1 = new Artwork("Zowie is een baas", new Money(34M), "dit is een test", artist1, DateTime.Now);
                /*Artwork artwork2 = new Artwork("Test1", new Money(34M), "dit is een test", artist2, DateTime.Now);
                Artwork artwork3 = new Artwork("Test2", new Money(34M), "dit is een test", artist3, DateTime.Now);*/
                artwork1.ImagePath = $"/images/artworks/1.jpg";
              /*  artwork2.ImagePath = $"/images/artworks/2.jpg";
                artwork3.ImagePath = $"/images/artworks/3.jpg";*/
                List<Artwork> artworks = new List<Artwork> { artwork1/*, artwork2, artwork3*/};
              

                artist1.Artworks = artworks;

                _dbContext.Artworks.AddRange(artworks);
                
                _dbContext.SaveChanges();

            }
        }


    }
}