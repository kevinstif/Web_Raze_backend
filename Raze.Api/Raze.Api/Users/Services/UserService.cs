using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Domain.Repositories;
using Raze.Api.Users.Domain.Services;
using Raze.Api.Users.Domain.Services.Communication;

namespace Raze.Api.Users.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

   
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<SaveUserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
                return new SaveUserResponse(user);
            }
            catch (Exception e)
            {
          
                return new SaveUserResponse($"error:{e.Message}");
            }
        }
    }
}