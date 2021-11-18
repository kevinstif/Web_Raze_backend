using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Raze.Api.Domain.Services;
using Raze.Api.Extensions;
using Raze.Api.Resources;
using Raze.Api.Security.Domain.Models;
using Raze.Api.Security.Domain.Services;
using Raze.Api.Security.Resources;

namespace Raze.Api.Controllers
{
    [Route("/api/v1/[controller]")]
    public class UsersController:ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var user = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(user);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<UserResource> GetByIdAsync(int id)
        {
            var user = await _userService.FindByIdAsync(id);
            var resource = _mapper.Map<User, UserResource>(user);

            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var user = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _userService.SaveAsync(user);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var user = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _userService.UpdateAsync(id, user);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }
    }
}