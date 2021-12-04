using EuropArt.Domain.Artists;
using EuropArt.Domain.Artworks;
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
    }
}
