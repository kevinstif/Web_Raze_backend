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
    public class UserAdvisorService:IUserAdvisorService
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

        public async Task<SaveUserAdvisorResponse> SaveAsync(UserAdvisor userAdvisor)
        {
            try
            {
                await _userAdvisorRepository.AddAsync(userAdvisor);
                await _unitOfWork.CompleteAsync();
                return new SaveUserAdvisorResponse(userAdvisor);
            }
            catch (Exception e)
            {
                return new SaveUserAdvisorResponse($"error:{e.Message}");
            }
        }
    }
}