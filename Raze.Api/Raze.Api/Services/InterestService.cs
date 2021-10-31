using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Repositories;
using Raze.Api.Domain.Services;

namespace Raze.Api.Services
{
    public class InterestService : IInterestService
    {
        private readonly IInterestRepository _interestRepository;
        
        public InterestService(IInterestRepository interestRepository)
        {
            _interestRepository = interestRepository;
        }
        
        public async Task<IEnumerable<Interest>> ListAsync()
        {
            return await _interestRepository.ListAsync();   
        }
    }
}