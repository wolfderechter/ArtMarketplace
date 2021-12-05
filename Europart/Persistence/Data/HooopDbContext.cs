using EuropArt.Domain.Artists;
using EuropArt.Domain.Artworks;
using EuropArt.Persistence.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Persistence.Data
{
    public class HooopDbContext : DbContext
    {

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public HooopDbContext(DbContextOptions<HooopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ArtistEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ArtworkEntityTypeConfiguration());
            
        }
    }
}
