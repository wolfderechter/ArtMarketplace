using EuropArt.Domain.Artists;
using EuropArt.Domain.Artworks;
using EuropArt.Domain.Likes;
using EuropArt.Domain.Messages;
using EuropArt.Persistence.Data;
using EuropArt.Shared.Accounts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropArt.Services.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly HooopDbContext dbContext;
        private readonly DbSet<Artist> artists;
        private readonly DbSet<Artwork> artworks;
        private readonly DbSet<Like> likes;
        private readonly DbSet<Conversation> conversations;


        public AccountService(HooopDbContext dbContext)
        {
            this.dbContext = dbContext;
            artists = dbContext.Artists;
            likes = dbContext.Likes;
            artworks = dbContext.Artworks;
            conversations = dbContext.Conversations;
        }
        public async Task AddLikeAsync(AccountRequest.AddLike request)
        {
            var artist = await artists.Where(p => p.AuthId == request.AuthId).SingleOrDefaultAsync();
            var artwork = await artworks.Where(p => p.Id == request.ArtworkId).SingleOrDefaultAsync();
            Like like = new Like(artist.AuthId, artwork);

            artist.Likes.Add(like);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteLikeAsync(AccountRequest.DeleteLike request)
        {
             var like = likes
            .AsNoTracking()
            .Where(l => l.AuthId == request.AuthId && l.ArtworkId == request.ArtworkId).SingleOrDefault();

            likes.Remove(like);
            await dbContext.SaveChangesAsync();
        }

        public async Task<AccountResponse.GetConversations> GetConversationsAsync(AccountRequest.GetConversations request)
        {
            await Task.Delay(100);
            AccountResponse.GetConversations response = new();
            response.Conversations = conversations.Include(c => c.Messages).Where(l => l.UserAuthId == request.AuthId || l.ArtistAuthId == request.AuthId).ToList();
            return response;
        }

        public async Task<AccountResponse.GetLikes> GetLikesAsync(AccountRequest.GetLikes request)
        {
            AccountResponse.GetLikes response = new();
            response.ArtworkIds = likes.Where(l => l.AuthId == request.AuthId).Select(l => l.ArtworkId).ToList();
            return response;
        }
    }
}
