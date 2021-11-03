using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Domain.Services;
using Raze.Api.Users.Extensions;
using Raze.Api.Users.Resources;

namespace Raze.Api.Users.Controllers
{
    [Route("/api/v1/[controller]")]
    public class UsersAdvisorsController:ControllerBase
    {
        private readonly IUserAdvisorService _userAdvisorService;
        private readonly IMapper _mapper;

        public UsersAdvisorsController(IUserAdvisorService userAdvisorService, IMapper mapper)
        {
            _userAdvisorService = userAdvisorService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<UserAdvisor>> GetAllAsync()
        {
            var userAdvisors = await _userAdvisorService.ListAsync();
            return userAdvisors;
        }
        
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserAdvisorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            Console.WriteLine("nAqyu muere :c");
            Console.WriteLine("nunca llego");
            var userAdvisor = _mapper.Map<SaveUserAdvisorResource, UserAdvisor>(resource);
            var result = await _userAdvisorService.SaveAsync(userAdvisor);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.UserAdvisor);
        }
    }
}