using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Raze.Api.Domain.Services;
using Raze.Api.Domain.Models;
using Raze.Api.Resources;

namespace Raze.Api.Controllers
{
    [Route("/api/v1/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PostResource>> GetAllAsync()
        {
            var posts = await _postService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePostResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
        }
    }
}