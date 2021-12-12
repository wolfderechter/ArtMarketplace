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
    public class YouthArtistEntityTypeConfiguration : IEntityTypeConfiguration<YouthArtist>
    {
        public void Configure(EntityTypeBuilder<YouthArtist> builder)
        {
            builder.HasKey(y => y.Id);
            builder.Property(n => n.FirstName).HasColumnName("Firstname").IsRequired();
            builder.Property(n => n.LastName).HasColumnName("Lastname").IsRequired();
            builder.Property(a => a.Street).HasColumnName("Street");
            builder.Property(a => a.Postalcode).HasColumnName("Postalcode");
            builder.Property(a => a.City).HasColumnName("City");
            builder.Property(a => a.Country).HasColumnName("Country");
        }
    }
}
