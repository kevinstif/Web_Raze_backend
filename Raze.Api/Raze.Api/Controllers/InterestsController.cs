﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services;
using Raze.Api.Extensions;
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
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveInterestResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var interest = _mapper.Map<SaveInterestResource, Interest>(resource);

            var result = await _interestService.SaveAsync(interest);

            if (!result.Success)
                return BadRequest(result.Message);

            var interestResource = _mapper.Map<Interest, InterestResource>(result.Interest);
            return Ok(interestResource);
        }
    }
}