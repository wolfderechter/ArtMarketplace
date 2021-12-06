using EuropArt.Domain.YouthArtworks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Persistence.Data.Configuration
{
    public class YouthArtworkEntityTypeConfiguration : IEntityTypeConfiguration<YouthArtwork>
    {
        public void Configure(EntityTypeBuilder<YouthArtwork> builder)
        {
            builder.HasKey(y => y.Id);
            builder.Property(y => y.Name).IsRequired();
            builder.HasOne(y => y.YouthArtist).WithMany(y => y.Artworks);
        }
    }
}
