using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Users.Domain.Repositories
{
    public interface IUserAdvisorRepository
    {
        Task<IEnumerable<AdvisorUser>> ListAsync();
        Task<IEnumerable<AdvisorUser>> FindByProfessionId(int id);
        Task AddAsync(AdvisorUser advisorUser);
        Task<AdvisorUser> FindbyIdAsync(int id);
        
        void Update(AdvisorUser advisorUser);
        void Remove(AdvisorUser advisorUser);

    }
}