using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Models;

namespace Raze.Api.Domain.Repositories
{
    public interface IProfessionRepository
    {
        Task<IEnumerable<Profession>> ListAsync();
        Task AddAsync(Profession profession);
        Task<Profession> FindByIdAsync(int id);
        void Update(Profession profession);
        void Remove(Profession profession);
    }
}