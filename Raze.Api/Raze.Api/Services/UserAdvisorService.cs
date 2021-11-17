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
        private readonly IProfessionRepository _professionRepository;

        public UserAdvisorService(IUserAdvisorRepository userAdvisorRepository, IUnitOfWork unitOfWork, IProfessionRepository professionRepository)
        {
            _userAdvisorRepository = userAdvisorRepository;
            _unitOfWork = unitOfWork;
            _professionRepository = professionRepository;
        }

        public async Task<IEnumerable<AdvisorUser>> ListAsync()
        {
            return await _userAdvisorRepository.ListAsync();
        }
        
        public async Task<IEnumerable<AdvisorUser>> ListByProfessionAsync(int professionId)
        {
            return await _userAdvisorRepository.FindByProfessionId(professionId);
        }

        public async Task<UserAdvisorResponse> SaveAsync(AdvisorUser advisorUser)
        {
            var existingProfession = await _professionRepository.FindByIdAsync(advisorUser.ProfessionId);
            if (existingProfession == null)
            {
                return new UserAdvisorResponse("Profession not found.");
            }
            
            try
            {
                await _userAdvisorRepository.AddAsync(advisorUser);
                await _unitOfWork.CompleteAsync();
                return new UserAdvisorResponse(advisorUser);
            }
            catch (Exception e)
            {
                return new UserAdvisorResponse($"error:{e.Message}");
            }
        }

        public async Task<UserAdvisorResponse> UpdateAsync(int id, AdvisorUser advisorUser)
        {
            var existingUserAdvisor = await _userAdvisorRepository.FindbyIdAsync(id);
            if (existingUserAdvisor == null)
                return new UserAdvisorResponse("User not found");
            existingUserAdvisor.UserName = advisorUser.UserName;
            existingUserAdvisor.InterestId = advisorUser.InterestId;
            existingUserAdvisor.ProfessionId = advisorUser.ProfessionId;
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