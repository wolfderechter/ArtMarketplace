using EuropArt.Domain.Artists;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Persistence.Data.Configuration
{
    public class ArtistEntityTypeConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            
            builder.Property(p => p.Name).IsRequired();
            builder.HasMany(p => p.Artworks).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
