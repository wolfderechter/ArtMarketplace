using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Users
{
    public interface IUserService
    {
        Task<UserResponse.Create> CreateAsync(UserRequest.Create request);
        Task<UserResponse.GetIndex> GetIndexAsync(UserRequest.GetIndex request);
        bool CheckIfUser(string authId);
    }
}
