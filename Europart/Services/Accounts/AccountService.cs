using EuropArt.Domain.Artists;
using EuropArt.Domain.Artworks;
using EuropArt.Domain.Likes;
using EuropArt.Domain.Messages;
using EuropArt.Domain.Users;
using EuropArt.Persistence.Data;
using EuropArt.Shared.Accounts;
using Microsoft.EntityFrameworkCore;
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
        private readonly DbSet<User> users;


        public AccountService(HooopDbContext dbContext)
        {
            this.dbContext = dbContext;
            artists = dbContext.Artists;
            likes = dbContext.Likes;
            artworks = dbContext.Artworks;
            conversations = dbContext.Conversations;
            users = dbContext.Users;
        }
        public async Task AddLikeAsync(AccountRequest.AddLike request)
        {
            var artist = await artists.Where(p => p.AuthId == request.AuthId).SingleOrDefaultAsync();
            var artwork = await artworks.Where(p => p.Id == request.ArtworkId).SingleOrDefaultAsync();
            Like like = new Like(artist.AuthId, artwork);

            artist.Likes.Add(like);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddMessageAsync(AccountRequest.AddMessage request)
        {
            var conversation = await conversations.Where(c => c.Id == request.ConversationId).SingleOrDefaultAsync();
            Message message = new Message(request.NewMessage.Content, request.NewMessage.DateCreated, request.NewMessage.AuthId);
            conversation.Messages.Add(message);
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

        public async Task<AccountResponse.GetIndex> GetIndexAsync(AccountRequest.GetIndex request)
        {
            await Task.Delay(100);
            AccountResponse.GetIndex response = new();

            //Query om te filteren


            //wanneer request komt van buiten artist page -> snel resultaten terugeven
            //orderby niet opgevuld dus niet in artist index page
            response.User = await users.AsNoTracking().Where(p => p.AuthId == request.AuthId).Select(x => new AccountDto.Index
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateCreated = x.DateCreated,
                AuthId = x.AuthId
            }).SingleOrDefaultAsync();

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
