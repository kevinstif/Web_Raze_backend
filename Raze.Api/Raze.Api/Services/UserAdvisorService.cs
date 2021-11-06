using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Repositories;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Domain.Repositories;
using Raze.Api.Domain.Services;
using Raze.Api.Domain.Services.Communication;

namespace Raze.Api.Users.Services
{
    public class UserAdvisorService : IUserAdvisorService
    {
        private readonly IUserAdvisorRepository _userAdvisorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserAdvisorService(IUserAdvisorRepository userAdvisorRepository, IUnitOfWork unitOfWork)
        {
            _userAdvisorRepository = userAdvisorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserAdvisor>> ListAsync()
        {
            return await _userAdvisorRepository.ListAsync();
        }

        public async Task<UserAdvisorResponse> SaveAsync(UserAdvisor userAdvisor)
        {
            try
            {
                await _userAdvisorRepository.AddAsync(userAdvisor);
                await _unitOfWork.CompleteAsync();
                return new UserAdvisorResponse(userAdvisor);
            }
            catch (Exception e)
            {
                return new UserAdvisorResponse($"error:{e.Message}");
            }
        }

        public async Task<UserAdvisorResponse> UpdateAsync(int id, UserAdvisor userAdvisor)
        {
            var existingUserAdvisor = await _userAdvisorRepository.FindbyIdAsync(id);
            if (existingUserAdvisor == null)
                return new UserAdvisorResponse("User not found");
            existingUserAdvisor.UserName = userAdvisor.UserName;
            existingUserAdvisor.Profession = userAdvisor.Profession;
            existingUserAdvisor.InterestId = userAdvisor.InterestId;
            try
            {
                _userAdvisorRepository.Update(existingUserAdvisor);
                await _unitOfWork.CompleteAsync();
                return new UserAdvisorResponse(existingUserAdvisor);

            }
            catch (Exception e)
            {
                return new UserAdvisorResponse($"An error ocurred while updating the userAdvice :{e.Message}");
                
            }
        }

        public async Task<UserAdvisorResponse> DeleteAsync(int id)
        {
            var existingUserAdvisor = await _userAdvisorRepository.FindbyIdAsync(id);
            if (existingUserAdvisor == null)
                return new UserAdvisorResponse("UserAdvisor not found");
            try
            {
                _userAdvisorRepository.Remove(existingUserAdvisor);
                await _unitOfWork.CompleteAsync();
                return new UserAdvisorResponse(existingUserAdvisor);
            }
            catch (Exception e)
            {
                return new UserAdvisorResponse($"An error ocurred while deleting the userAdvice :{e.Message}");
            }
        }
    }
}