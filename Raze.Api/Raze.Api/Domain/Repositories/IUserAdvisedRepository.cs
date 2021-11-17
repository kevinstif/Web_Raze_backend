using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Users.Domain.Repositories
{
    public interface IUserAdvisedRepository
    {
        Task<IEnumerable<AdvisedUser>> ListAsync();
        Task AddAsync(AdvisedUser advisedUser);
        Task<AdvisedUser> FindbyIdAsync(int id);
        void Update(AdvisedUser advisedUser);
        void Remove(AdvisedUser advisedUser);
    }
    
}