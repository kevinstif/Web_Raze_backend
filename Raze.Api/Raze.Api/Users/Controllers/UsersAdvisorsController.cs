using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Domain.Services;

namespace Raze.Api.Users.Controllers
{
    [Route("/api/v1/[controller]")]
    public class UsersAdvisorsController:ControllerBase
    {
        private readonly IUserAdvisorService _userAdvisorService;

        public UsersAdvisorsController(IUserAdvisorService userAdvisorService)
        {
            _userAdvisorService = userAdvisorService;
        }
        [HttpGet]
        public async Task<IEnumerable<UserAdvisor>> GetAllAsync()
        {
            var userAdvisors = await _userAdvisorService.ListAsync();
            return userAdvisors;
        }
    }
}