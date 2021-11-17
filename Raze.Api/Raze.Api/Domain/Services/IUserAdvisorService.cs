using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Domain.Services.Communication;

namespace Raze.Api.Domain.Services
{
    public interface IUserAdvisorService
    {
        Task<IEnumerable<AdvisorUser>> ListAsync();
        Task<UserAdvisorResponse> SaveAsync(AdvisorUser advisorUser);
        Task<UserAdvisorResponse> UpdateAsync(int id, AdvisorUser advisorUser);

        Task<UserAdvisorResponse> DeleteAsync(int id);
        Task<IEnumerable<AdvisorUser>> ListByProfessionAsync(int professionId);
    }
}