using EuropArt.Domain.Likes;
using EuropArt.Domain.Messages;
using EuropArt.Domain.Users;
using EuropArt.Persistence.Data;
using EuropArt.Shared.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Services.Users
{
    public class UserService : IUserService
    {
        private readonly HooopDbContext dbContext;
        private readonly DbSet<Like> likes;
        private readonly DbSet<Conversation> conversations;
        private readonly DbSet<User> users;
        public UserService(HooopDbContext dbContext)
        {
            this.dbContext = dbContext;
            likes = dbContext.Likes;
            conversations = dbContext.Conversations;
            users = dbContext.Users;
        }
        public async Task<UserResponse.Create> CreateAsync(UserRequest.Create request)
        {
            await Task.Delay(100);
            UserResponse.Create response = new();
            var model = request.User;

            var user = users.Add(new User(model.FirstName, model.LastName, model.AuthId, DateTime.Now));

            await dbContext.SaveChangesAsync();
            response.UserId = user.Entity.Id;

            return response;
        }

        public async Task<UserResponse.GetIndex> GetIndexAsync(UserRequest.GetIndex request)
        {
            await Task.Delay(100);
            UserResponse.GetIndex response = new();

            //Query om te filteren


            //wanneer request komt van buiten artist page -> snel resultaten terugeven
            //orderby niet opgevuld dus niet in artist index page
            response.User = await users.Include(u => u.Likes).ThenInclude(u => u.Artwork).AsNoTracking().Where(p => p.AuthId == request.AuthId).Select(x => new UserDto.Index
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateCreated = x.DateCreated,
                AuthId = x.AuthId,
                Likes = x.Likes.ToList()

            }).SingleOrDefaultAsync();

            return response;
        }

        public bool CheckIfUser(string authId)
        {
            var user = users.Single(u => u.AuthId == authId);
            return user != null;
        }
    }
}
