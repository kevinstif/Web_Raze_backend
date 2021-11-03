using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Domain.Services.Communication;

namespace Raze.Api.Domain.Services
{
    public interface IUserAdvisorService
    {
        Task<IEnumerable<UserAdvisor>> ListAsync();
        Task<SaveUserAdvisorResponse> SaveAsync(UserAdvisor userAdvisor);
    }
}