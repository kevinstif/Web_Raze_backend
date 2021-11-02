using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Users.Domain.Repositories
{
    public interface IUserAdvisorRepository
    {
        Task<IEnumerable<UserAdvisor>> ListAsync();
    }
}