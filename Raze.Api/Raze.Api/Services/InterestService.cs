using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Repositories;
using Raze.Api.Domain.Services;
using Raze.Api.Domain.Services.Communication;

namespace Raze.Api.Services
{
    public class InterestService : IInterestService
    {
        private readonly IInterestRepository _interestRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public InterestService(IInterestRepository interestRepository, IUnitOfWork unitOfWork)
        {
            _interestRepository = interestRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Interest>> ListAsync()
        {
            return await _interestRepository.ListAsync();   
        }

        public async Task<SaveInterestResponse> SaveAsync(Interest interest)
        {
            try
            {
                await _interestRepository.AddAsync(interest);
                await _unitOfWork.CompleteAsync();

                return new SaveInterestResponse(interest);
            }
            catch (Exception e)
            {
                return new SaveInterestResponse($"An error occurred while saving the category: {e.Message}");
            }
        }
    }
}