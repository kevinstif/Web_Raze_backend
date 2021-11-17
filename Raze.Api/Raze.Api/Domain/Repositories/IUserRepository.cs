using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Users.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task<IEnumerable<User>> FindByProfessionId(int id);
        Task<User> FindByIdAsync(int id);
        Task AddAsync(User user);
        Task<User> FindbyIdAsync(int id);
        void Update(User user);
        void Remove(User user);

    }
}