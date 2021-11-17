using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Domain.Services.Communication;

namespace Raze.Api.Users.Domain.Services
{
    public interface IUserAdvisedService
    {
        Task<IEnumerable<AdvisedUser>> ListAsync();
        Task<UserAdvisedResponse> SaveAsync(AdvisedUser advisedUser);
        Task<UserAdvisedResponse> UpdateAsync(int id, AdvisedUser advisedUser);

        Task<UserAdvisedResponse> DeleteAsync(int id);
    }
}