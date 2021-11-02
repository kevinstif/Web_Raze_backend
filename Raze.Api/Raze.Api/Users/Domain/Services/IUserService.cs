using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Domain.Services.Communication;

namespace Raze.Api.Users.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<SaveUserResponse> SaveAsync(User user);
    }
}