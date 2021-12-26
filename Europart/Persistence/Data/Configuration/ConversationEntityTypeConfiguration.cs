using EuropArt.Domain.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Persistence.Data.Configuration
{
    public class ConversationEntityTypeConfiguration : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.ToTable("Converstions");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.ArtistAuthId);
            builder.Property(l => l.UserAuthId);
            builder.HasMany(l => l.Messages).WithOne();
           

        }
    }
}
