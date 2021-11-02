using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Domain.Services;

namespace Raze.Api.Users.Controllers
{
    [Route("/api/v1/[controller]")]
    public class UsersAdvisedsController:ControllerBase
    {
        private readonly IUserAdvisedService _userAdvisedService;

        public UsersAdvisedsController(IUserAdvisedService userAdvisedService)
        {
            _userAdvisedService = userAdvisedService;
        }
        [HttpGet]
        public async Task<IEnumerable<UserAdvised>> GetAllAsync()
        {
            var usersAdviseds = await _userAdvisedService.ListAsync();
            return usersAdviseds;
        }
    }
}