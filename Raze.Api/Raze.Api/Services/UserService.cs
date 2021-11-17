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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProfessionRepository _professionRepository;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IProfessionRepository professionRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _professionRepository = professionRepository;
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<User> FindByIdAsync(int id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            return user;
        }

        public async Task<IEnumerable<User>> ListByProfessionAsync(int professionId)
        {
            return await _userRepository.FindByProfessionId(professionId);
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            var existingProfession = await _professionRepository.FindByIdAsync(user.ProfessionId);
            if (existingProfession == null)
            {
                return new UserResponse("Profession not found.");
            }
            
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch (Exception e)
            {
                return new UserResponse($"error:{e.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingUser = await _userRepository.FindbyIdAsync(id);
            if (existingUser == null)
                return new UserResponse("User not found");
            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.ImgProfile = user.ImgProfile;
            existingUser.InterestId = user.InterestId;
            existingUser.ProfessionId = user.ProfessionId;
            existingUser.Premium = user.Premium;
            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(existingUser);

            }
            catch (Exception e)
            {
                return new UserResponse($"An error ocurred while updating the userAdvice :{e.Message}");
                
            }
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindbyIdAsync(id);
            if (existingUser == null)
                return new UserResponse("User not found");
            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(existingUser);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error ocurred while deleting the user :{e.Message}");
            }
        }
    }
}