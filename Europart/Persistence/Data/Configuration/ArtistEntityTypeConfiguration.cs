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
            builder.Property(n => n.FirstName).HasColumnName("Firstname").IsRequired();
            builder.Property(n => n.LastName).HasColumnName("Lastname").IsRequired();
            builder.Property(a => a.Street).HasColumnName("Street").IsRequired();
            builder.Property(a => a.Postalcode).HasColumnName("Postalcode").IsRequired();
            builder.Property(a => a.City).HasColumnName("City").IsRequired();
            builder.Property(a => a.Country).HasColumnName("Country").IsRequired();

            builder.HasMany(p => p.Artworks).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
