using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Domain.Services;
using Raze.Api.Extensions;
using Raze.Api.Resources;
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
        public async Task<IEnumerable<UserAdvisedResource>> GetAllAsync()
        {
            var usersAdviseds = await _userAdvisedService.ListAsync();
            var resources = _mapper.Map<IEnumerable<AdvisedUser>, IEnumerable<UserAdvisedResource>>(usersAdviseds);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserAdvisedResource resource)
        {
             if (!ModelState.IsValid)
               return BadRequest(ModelState.GetErrorMessages());
             var userAdvised = _mapper.Map<SaveUserAdvisedResource, AdvisedUser>(resource);
             var result = await _userAdvisedService.SaveAsync(userAdvised);
             if (!result.Success)
                 return BadRequest(result.Message);
             
             var userAdvisedResource = _mapper.Map<AdvisedUser, UserAdvisedResource>(result.Resource);
             return Ok(userAdvisedResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserAdvisedResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var userAdvised = _mapper.Map<SaveUserAdvisedResource, AdvisedUser>(resource);
            var result = await _userAdvisedService.UpdateAsync(id, userAdvised);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var userAdvisedResource = _mapper.Map<AdvisedUser, UserAdvisedResource>(result.Resource);
            return Ok(userAdvisedResource);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userAdvisedService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var userAdvisedResource = _mapper.Map<AdvisedUser, UserAdvisedResource>(result.Resource);
            return Ok(userAdvisedResource);
        }
    }
}