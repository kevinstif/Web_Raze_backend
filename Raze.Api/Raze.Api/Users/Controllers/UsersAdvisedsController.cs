using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
    public class UsersAdvisedsController:ControllerBase
    {
        private readonly IUserAdvisedService _userAdvisedService;
        private readonly IMapper _mapper;

        public UsersAdvisedsController(IUserAdvisedService userAdvisedService, IMapper mapper)
        {
            _userAdvisedService = userAdvisedService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<UserAdvised>> GetAllAsync()
        {
            var usersAdviseds = await _userAdvisedService.ListAsync();
            return usersAdviseds;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserAdvisedResource resource)
        {
             if (!ModelState.IsValid)
               return BadRequest(ModelState.GetErrorMessages());
             var userAdvised = _mapper.Map<SaveUserAdvisedResource, UserAdvised>(resource);
             var result = await _userAdvisedService.SaveAsync(userAdvised);
             if (!result.Success)
                 return BadRequest(result.Message);
             return Ok(result.UserAdvised);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserAdvisedResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var userAdvised = _mapper.Map<SaveUserAdvisedResource, UserAdvised>(resource);
            var result = await _userAdvisedService.UpdateAsync(id, userAdvised);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.UserAdvised);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userAdvisedService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.UserAdvised);
        }
    }
}