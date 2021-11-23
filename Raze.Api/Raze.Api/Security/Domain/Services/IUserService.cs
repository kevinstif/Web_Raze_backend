using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Security.Domain.Models;
using Raze.Api.Security.Domain.Services.Communication;
using Raze.Api.Security.Resources;

namespace Raze.Api.Security.Domain.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
        Task<IEnumerable<User>> ListAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> GetByEmailAsync(string email);
        Task RegisterAsync(SaveUserResource request);
        Task UpdateAsync(int id, UpdateUserResource request);
        //Task DeleteAsync(int id);
        
        Task<User> FindByIdAsync(int id);
        //Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(int id, User user);
        Task<UserResponse> DeleteAsync(int id);
        Task<IEnumerable<User>> ListByProfessionAsync(int professionId);
    }
}