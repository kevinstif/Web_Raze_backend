using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    
        public async Task<IEnumerable<UserAdvised>> ListAsync()
        {
            return await _userAdvisedRepository.ListAsync();
        }

        public async Task<SaveUserAdvisedResponse> SaveAsync(UserAdvised userAdvised)
        {
            try
            {
                await _userAdvisedRepository.AddAsync(userAdvised);
                await _unitOfWork.CompleteAsync();
                return new SaveUserAdvisedResponse(userAdvised);
            }
            catch (Exception e)
            {
              
                return new SaveUserAdvisedResponse($"error:{e.Message}");
            }
        }
    }
}