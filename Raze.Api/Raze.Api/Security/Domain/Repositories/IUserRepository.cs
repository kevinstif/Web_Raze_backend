using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Security.Domain.Models;

namespace Raze.Api.Security.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);
        Task<IEnumerable<User>> FindByProfessionId(int id);
        Task<User> FindByIdAsync(int id);
        Task<User> FindByEmailAsync(string email);
        public bool ExistsByEmail(string email);
        User FindById(int id);
        
        void Update(User user);
        void Remove(User user);

    }
}