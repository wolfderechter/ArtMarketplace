using EuropArt.Domain.Likes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Persistence.Data.Configuration
{
    public class LikeEntityTypeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.ToTable("Likes");
            builder.HasKey(l => new { l.AuthId, l.ArtworkId });

            builder.Property(l => l.AuthId);
            builder.HasOne(l => l.Artwork).WithMany().HasForeignKey(l => l.ArtworkId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
