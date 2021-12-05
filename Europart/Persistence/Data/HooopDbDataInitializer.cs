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
                Artist artist1 = new Artist("Stef Boerjan", "Lokeren", "Nietsnut", "www.ikkanniets.be", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/123.jpg", DateTime.Now);
                Artist artist2 = new Artist("Dylan", "Zele", "Ik doe niks", "www.ikhebschijtaanalles.be", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/234.jpg", DateTime.Now);
                Artist artist3 = new Artist("Zowie Verschuere", "Gent", "Baas", "www.ikbendebeste.be", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/666.jpg", DateTime.Now);

                Artwork artwork1 = new Artwork("Zowie is een baas", new Money(34M), "dit is een test", artist1, DateTime.Now);

                List<Artwork> artworks = new List<Artwork> { artwork1 };
                artist1.Artworks = artworks;

            }
        }


    }
}