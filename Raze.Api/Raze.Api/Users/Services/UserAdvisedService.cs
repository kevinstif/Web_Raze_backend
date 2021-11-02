using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Domain.Services;
using Raze.Api.Users.Domain.Repositories;
namespace Raze.Api.Users.Services
{
    public class UserAdvisedService:IUserAdvisedService
    {
        private readonly IUserAdvisedRepository _userAdvisedRepository;
        public UserAdvisedService(IUserAdvisedRepository userAdvisedRepository)
        {
            _userAdvisedRepository = userAdvisedRepository;
        }

    
        public async Task<IEnumerable<UserAdvised>> ListAsync()
        {
            return await _userAdvisedRepository.ListAsync();
        }
    }
}