using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services.Communication;

namespace Raze.Api.Domain.Services
{
    public interface IInterestService
    {
        Task<IEnumerable<Interest>> ListAsync();
        Task<InterestResponse> SaveAsync(Interest interest);
        Task<InterestResponse> UpdateAsync(int id, Interest interest);
        Task<InterestResponse> DeleteAsync(int id);
        Task<InterestResponse> GetByIdAsync(int id);
        /*Task<InterestResponse> GetByTitleAsync(string title);*/

    }
}