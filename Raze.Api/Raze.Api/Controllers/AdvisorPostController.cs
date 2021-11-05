using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services;
using Raze.Api.Resources;

namespace Raze.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/usersadvisors/{userId}/posts")]
    public class AdvisorPostController
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public AdvisorPostController(IMapper mapper, IPostService postService)
        {
            _mapper = mapper;
            _postService = postService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<PostResource>> GetAllByUserIdAsync(int userId)
        {
            var posts = await _postService.ListByAdvisorAsync(userId);
            var resources = _mapper.Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);
            return resources;
        }
    }
}