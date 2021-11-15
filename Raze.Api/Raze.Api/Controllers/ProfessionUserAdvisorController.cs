using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services;
using Raze.Api.Resources;
using Raze.Api.Users.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Raze.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/professions/{professionId}/usersadvisors")]
    public class ProfessionUserAdvisorController: ControllerBase
    {
        private readonly IUserAdvisorService _userAdvisorService;
        private readonly IMapper _mapper;

        public ProfessionUserAdvisorController(IUserAdvisorService userAdvisorService, IMapper mapper)
        {
            _userAdvisorService = userAdvisorService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get All Users Advisor By Profession",
            Description = "Get All Users Advisor for a the given UserAdvisorId.",
            Tags = new []{"Professions"})]
        public async Task<IEnumerable<UserAdvisorResource>> GetAllByUserIdAsync(int professionId)
        {
            var userAdvisors = await _userAdvisorService.ListByProfessionAsync(professionId);
            var resources = _mapper.Map<IEnumerable<UserAdvisor>, IEnumerable<UserAdvisorResource>>(userAdvisors);
            return resources;
        }
    }
}