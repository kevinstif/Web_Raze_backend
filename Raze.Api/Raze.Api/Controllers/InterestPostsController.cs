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
    [Route("/api/v1/interests/{interestId}/posts")]
    public class InterestPostsController: ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public InterestPostsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<PostResource>> GetAllByUserIdAsync(int interestId)
        {
            var posts = await _postService.ListByInterestAsync(interestId);
            var resources = _mapper.Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);
            return resources;
        }
    }
}