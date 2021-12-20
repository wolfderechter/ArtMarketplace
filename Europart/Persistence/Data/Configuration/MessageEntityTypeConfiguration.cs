using EuropArt.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Persistence.Data.Configuration
{
    public class MessageEntityTypeConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");
            builder.HasKey(m => m.Id);
            builder.HasOne(m => m.Artist).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(m => m.YouthArtist).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.Property(m => m.DateCreated);
            builder.Property(m => m.Content);
            builder.Property(m => m.ReceiverId);
            builder.Property(m => m.SenderId);
        }
    }
}
