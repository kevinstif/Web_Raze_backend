using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services.Communication;

namespace Raze.Api.Domain.Services
{
    public interface IProfessionService
    {
        Task<IEnumerable<Profession>> ListAsync();
        Task<ProfessionResponse> SaveAsync(Profession profession);
        Task<ProfessionResponse> UpdateAsync(int id, Profession profession);
        Task<ProfessionResponse> DeleteAsync(int id);
        Task<ProfessionResponse> GetByIdAsync(int id);
    }
}