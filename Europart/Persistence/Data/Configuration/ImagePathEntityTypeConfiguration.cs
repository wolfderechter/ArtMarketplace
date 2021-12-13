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
    public class ImagePathEntityTypeConfiguration : IEntityTypeConfiguration<ImagePath>
    {
        public void Configure(EntityTypeBuilder<ImagePath> builder)
        {
            builder.HasKey(y => y.imagePath);
        }
    }
}
