using EuropArt.Domain.Artists;
using EuropArt.Domain.Artworks;
using EuropArt.Domain.Common;
using EuropArt.Domain.Likes;
using EuropArt.Domain.Messages;
using EuropArt.Domain.Users;
using EuropArt.Domain.YouthArtworks;
using EuropArt.Persistence.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EuropArt.Persistence.Data
{
    public class HooopDbContext : DbContext
    {

        public DbSet<Artist> Artists { get; set; }
        public DbSet<YouthArtist> YouthArtists { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<YouthArtwork> YouthArtworks { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImagePath> ImagePaths { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public HooopDbContext(DbContextOptions<HooopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ArtistEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ArtworkEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new YouthArtworkEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new YouthArtistEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LikeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MessageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ImagePathEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ConversationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            
        }
    }
}
