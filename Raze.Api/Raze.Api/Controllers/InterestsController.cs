using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services;
using Raze.Api.Resources;

namespace Raze.Api.Controllers
{
    [Route("/api/v1/[controller]")]
    public class InterestsController : ControllerBase
    {
        private readonly IInterestService _interestService;

        private readonly IMapper _mapper;

        public InterestsController(IInterestService interestService, IMapper mapper)
        {
            _interestService = interestService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<InterestResource>> GetAllAsync()
        {
            var interests = await _interestService.ListAsync();

            var resources = _mapper.Map<IEnumerable<Interest>, IEnumerable<InterestResource>>(interests);
            return resources;
        }
    }
}