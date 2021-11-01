using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Models;

namespace Raze.Api.Domain.Repositories
{
    public interface IInterestRepository
    {
        Task<IEnumerable<Interest>> ListAsync();
        Task AddAsync(Interest interest);
        Task<Interest> FindByIdAsync(int id);
        void Update(Interest interest);
        void Remove(Interest interest);
    }
}