using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Domain.Repositories;
using Raze.Api.Users.Domain.Services;

namespace Raze.Api.Users.Services
{
    public class UserAdvisorService:IUserAdvisorService
    {
        private readonly IUserAdvisorRepository _userAdvisorRepository;

        public UserAdvisorService(IUserAdvisorRepository userAdvisorRepository)
        {
            _userAdvisorRepository = userAdvisorRepository;
        }

        public async Task<IEnumerable<UserAdvisor>> ListAsync()
        {
            return await _userAdvisorRepository.ListAsync();
        }
    }
}