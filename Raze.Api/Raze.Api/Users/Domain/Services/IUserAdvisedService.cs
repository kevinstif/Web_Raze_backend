using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Users.Domain.Services
{
    public interface IUserAdvisedService
    {
        Task<IEnumerable<UserAdvised>> ListAsync();
    }
}