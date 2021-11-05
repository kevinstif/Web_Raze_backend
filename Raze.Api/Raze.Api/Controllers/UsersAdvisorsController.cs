using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Domain.Services;
using Raze.Api.Extensions;
using Raze.Api.Resources;
using Raze.Api.Users.Resources;

namespace Raze.Api.Controllers
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
        public async Task<IEnumerable<UserAdvisorResource>> GetAllAsync()
        {
            var userAdvisors = await _userAdvisorService.ListAsync();
            var resources = _mapper.Map<IEnumerable<UserAdvisor>, IEnumerable<UserAdvisorResource>>(userAdvisors);
            return resources;
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
            
            var userAdvisorResource = _mapper.Map<UserAdvisor, UserAdvisorResource>(result.Resource);
            return Ok(userAdvisorResource);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserAdvisorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var userAdvisor = _mapper.Map<SaveUserAdvisorResource, UserAdvisor>(resource);
            var result = await _userAdvisorService.UpdateAsync(id, userAdvisor);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var userAdvisorResource = _mapper.Map<UserAdvisor, UserAdvisorResource>(result.Resource);
            return Ok(userAdvisorResource);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userAdvisorService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var userAdvisorResource = _mapper.Map<UserAdvisor, UserAdvisorResource>(result.Resource);
            return Ok(userAdvisorResource);
        }
    }
}