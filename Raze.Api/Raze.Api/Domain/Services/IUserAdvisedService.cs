using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Domain.Services.Communication;

namespace Raze.Api.Users.Domain.Services
{
    public interface IUserAdvisedService
    {
        Task<IEnumerable<UserAdvised>> ListAsync();
        Task<UserAdvisedResponse> SaveAsync(UserAdvised userAdvised);
        Task<UserAdvisedResponse> UpdateAsync(int id, UserAdvised userAdvised);

        Task<UserAdvisedResponse> DeleteAsync(int id);
    }
}