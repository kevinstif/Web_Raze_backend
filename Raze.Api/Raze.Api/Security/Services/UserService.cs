using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Raze.Api.Domain.Repositories;
using Raze.Api.Security.Authorization.Handlers.Interfaces;
using Raze.Api.Security.Domain.Models;
using Raze.Api.Security.Domain.Repositories;
using Raze.Api.Security.Domain.Services;
using Raze.Api.Security.Domain.Services.Communication;
using Raze.Api.Security.Exceptions;
using Raze.Api.Security.Resources;
using Raze.Api.Shared.Domain.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Raze.Api.Security.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProfessionRepository _professionRepository;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IProfessionRepository professionRepository, IJwtHandler jwtHandler, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _professionRepository = professionRepository;
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            var user = await _userRepository.FindByEmailAsync(request.Email);
            
            // Validate
            if (user == null || !BCryptNet.Verify(request.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect.");
            
            // Authentication successful
            var response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwtHandler.GenerateToken(user);
            return response;
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public async Task RegisterAsync(SaveUserResource request)
        {
            // Validate
            if (_userRepository.ExistsByEmail(request.Email))
                throw new AppException($"Email {request.Email} is already taken");
            
            // Map request to user
            var user = _mapper.Map<User>(request);
            
            // Hash Password
            user.PasswordHash = BCryptNet.HashPassword(request.Password);
            
            // Save User
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while saving the user: {e.Message}");
            }
        }

        public async Task UpdateAsync(int id, UpdateUserResource request)
        {
            var user = GetById(id);
            
            // Hash Password if entered
            if (!string.IsNullOrEmpty(request.Password))
                user.PasswordHash = BCryptNet.HashPassword(request.Password);
            
            // Map request to user
            _mapper.Map(request, user);
            
            try
            {
                _userRepository.Update(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while updating the user: {e.Message}");
            }
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
            var existingUser = await _userRepository.FindByIdAsync(id);
            if (existingUser == null)
                return new UserResponse("User not found");
            existingUser.Username = user.Username;
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
                return new UserResponse($"An error occurred while updating the userAdvice :{e.Message}");
                
            }
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);
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
                return new UserResponse($"An error occurred while deleting the user :{e.Message}");
            }
        }
        
        // Helper Methods
        private User GetById(int id)
        {
            var user = _userRepository.FindById(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}