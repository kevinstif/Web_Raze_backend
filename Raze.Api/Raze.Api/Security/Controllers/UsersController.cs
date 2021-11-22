using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Raze.Api.Extensions;
using Raze.Api.Resources;
using Raze.Api.Security.Authorization.Attributes;
using Raze.Api.Security.Domain.Models;
using Raze.Api.Security.Domain.Services;
using Raze.Api.Security.Domain.Services.Communication;
using Raze.Api.Security.Resources;

namespace Raze.Api.Security.Controllers
{
    [Authorize]
    [ApiController]
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

        [AllowAnonymous]
        [HttpPost("auth/sign-in")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest request)
        {
            var response = await _userService.Authenticate(request);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("auth/sign-up")]
        public async Task<IActionResult> Register(SaveUserResource request)
        {
            Console.WriteLine("Register:\n");
            await _userService.RegisterAsync(request);
            return Ok(new {message = "Registration successful"});
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            var resources = _mapper.Map<User, UserResource>(user);
            return Ok(resources);
        }
        
        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserResource request)
        {
            await _userService.UpdateAsync(id, request);
            return Ok(new {message = "User updated successfully."});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok(new {message = "User Deleted successfully"});
        }

        

        /*
         [HttpGet("{id}")]
        public async Task<UserResource> GetByIdAsync(int id)
        {
            var user = await _userService.FindByIdAsync(id);
            var resource = _mapper.Map<User, UserResource>(user);

            return resource;
        }
         
         [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var user = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(user);
            return resources;
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
        */
    }
}