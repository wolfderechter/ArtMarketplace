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
            builder.OwnsOne(c => c.Name, name =>
            {
                name.Property(n => n.FirstName).HasColumnName("Firstname").IsRequired();
                name.Property(n => n.LastName).HasColumnName("Lastname").IsRequired();
            }).Navigation(c => c.Name).IsRequired();

            builder.OwnsOne(c => c.Address, address =>
            {
                address.Property(a => a.Street).HasColumnName("Street");
                address.Property(a => a.Postalcode).HasColumnName("Postalcode");
                address.Property(a => a.City).HasColumnName("City");
                address.Property(a => a.Country).HasColumnName("Country");
            }).Navigation(c => c.Address).IsRequired();
        }
    }
}
