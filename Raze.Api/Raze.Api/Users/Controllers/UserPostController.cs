using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services;
using Raze.Api.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace Raze.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/user/{userId}/posts")]
    public class UserPostController: ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public UserPostController(IMapper mapper, IPostService postService)
        {
            _mapper = mapper;
            _postService = postService;
        }
        
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get All Posts By User",
            Description = "Get All Posts for a the given UserId.",
            Tags = new []{"Posts"})]
        public async Task<IEnumerable<PostResource>> GetAllByUserIdAsync(int userId)
        {
            var posts = await _postService.ListByUserAsync(userId);
            var resources = _mapper.Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);
            return resources;
        }
    }
}