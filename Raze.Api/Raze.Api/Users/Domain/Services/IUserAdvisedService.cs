using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Domain.Services.Communication;

namespace Raze.Api.Users.Domain.Services
{
    public interface IUserAdvisedService
    {
        Task<IEnumerable<UserAdvised>> ListAsync();
        Task<SaveUserAdvisedResponse> SaveAsync(UserAdvised userAdvised);
    }
}