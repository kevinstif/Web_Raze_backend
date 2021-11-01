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

        public async Task<InterestResponse> SaveAsync(Interest interest)
        {
            try
            {
                await _interestRepository.AddAsync(interest);
                await _unitOfWork.CompleteAsync();

                return new InterestResponse(interest);
            }
            catch (Exception e)
            {
                return new InterestResponse($"Error while saving interest: {e.Message}");
            }
        }

        public async Task<InterestResponse> UpdateAsync(int id, Interest interest)
        {
            var existingInterest = await _interestRepository.FindByIdAsync(id);

            if (existingInterest == null)
                return new InterestResponse("Not found");
            existingInterest.Title = interest.Title;
            existingInterest.Description = interest.Description;
            existingInterest.Published = interest.Published;

            try
            {
                _interestRepository.Update(existingInterest);
                await _unitOfWork.CompleteAsync();

                return new InterestResponse(existingInterest);
            }
            catch (Exception e)
            {
                return new InterestResponse($"Error while updating interest: {e.Message}");
            }
        }

        public async Task<InterestResponse> DeleteAsync(int id)
        {
            var existingInterest = await _interestRepository.FindByIdAsync(id);

            if (existingInterest == null)
                return new InterestResponse("Not found");

            try
            {
                _interestRepository.Remove(existingInterest);
                await _unitOfWork.CompleteAsync();

                return new InterestResponse(existingInterest);
            }
            catch (Exception e)
            {
                return new InterestResponse($"Error while deleting interest: {e.Message}");

            }
        }

        public async Task<InterestResponse> GetByIdAsync(int id)
        {
            var existingInterest = await _interestRepository.FindByIdAsync(id);
            return new InterestResponse(existingInterest);
        }
        
        /*public async Task<InterestResponse> GetByTitleAsync(string title)
        {
            var existingInterest = await _interestRepository.FindByTitleAsync(title);
            return new InterestResponse(existingInterest);
        }*/
    }
}