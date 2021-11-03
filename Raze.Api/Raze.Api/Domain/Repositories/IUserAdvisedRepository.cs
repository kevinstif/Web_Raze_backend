using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Users.Domain.Repositories
{
    public interface IUserAdvisedRepository
    {
        Task<IEnumerable<UserAdvised>> ListAsync();
        Task AddAsync(UserAdvised userAdvised);
        Task<UserAdvised> FindbyIdAsync(int id);
        void Update(UserAdvised userAdvised);
        void Remove(UserAdvised userAdvised);
    }
    
}