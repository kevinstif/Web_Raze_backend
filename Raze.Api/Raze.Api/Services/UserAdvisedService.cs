using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Repositories;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Domain.Services;
using Raze.Api.Users.Domain.Repositories;
using Raze.Api.Users.Domain.Services.Communication;

namespace Raze.Api.Users.Services
{
    public class UserAdvisedService:IUserAdvisedService
    {
        private readonly IUserAdvisedRepository _userAdvisedRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserAdvisedService(IUserAdvisedRepository userAdvisedRepository, IUnitOfWork unitOfWork)
        {
            _userAdvisedRepository = userAdvisedRepository;
            _unitOfWork = unitOfWork;
        }

    
        public async Task<IEnumerable<AdvisedUser>> ListAsync()
        {
            return await _userAdvisedRepository.ListAsync();
        }

        public async Task<UserAdvisedResponse> SaveAsync(AdvisedUser advisedUser)
        {
            try
            {
                await _userAdvisedRepository.AddAsync(advisedUser);
                await _unitOfWork.CompleteAsync();
                return new UserAdvisedResponse(advisedUser);
            }
            catch (Exception e)
            {
              
                return new UserAdvisedResponse($"error:{e.Message}");
            }
        }

        public async  Task<UserAdvisedResponse> UpdateAsync(int id, AdvisedUser advisedUser)
        {
            var existingUserAdvised = await _userAdvisedRepository.FindbyIdAsync(id);
            if (existingUserAdvised == null)
                return new UserAdvisedResponse("User not found");
            existingUserAdvised.UserName = advisedUser.UserName;
            existingUserAdvised.Mood = advisedUser.Mood;
            existingUserAdvised.InterestId = advisedUser.InterestId;
            try
            {
                _userAdvisedRepository.Update(existingUserAdvised);
                await _unitOfWork.CompleteAsync();
                return new UserAdvisedResponse(existingUserAdvised);

            }
            catch (Exception e)
            {
                return new UserAdvisedResponse($"An error ocurred while updating the userAdvice :{e.Message}");
                
            }
        }

        public async Task<UserAdvisedResponse> DeleteAsync(int id)
        {
            var existingUserAdvised = await _userAdvisedRepository.FindbyIdAsync(id);
            if (existingUserAdvised == null)
                return new UserAdvisedResponse("UserAdvised not found");
            try
            {
                _userAdvisedRepository.Remove(existingUserAdvised);
                await _unitOfWork.CompleteAsync();
                return new UserAdvisedResponse(existingUserAdvised);
            }
            catch (Exception e)
            {
                return new UserAdvisedResponse($"An error ocurred while deleting the userAdvice :{e.Message}");
            }
        
        }
    }
}