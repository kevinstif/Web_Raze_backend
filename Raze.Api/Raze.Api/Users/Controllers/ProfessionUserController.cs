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
    [Route("/api/v1/professions/{professionId}/user")]
    public class ProfessionUserController: ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ProfessionUserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get All Users By Profession",
            Description = "Get All Users for a the given UserId.",
            Tags = new []{"Users"})]
        public async Task<IEnumerable<UserResource>> GetAllByUserIdAsync(int professionId)
        {
            var user = await _userService.ListByProfessionAsync(professionId);
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(user);
            return resources;
        }
    }
}