using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Raze.Api.Domain.Services;
using Raze.Api.Domain.Models;
using Raze.Api.Extensions;
using Raze.Api.Resources;
using Raze.Api.Security.Authorization.Attributes;
using Swashbuckle.AspNetCore.Annotations;

namespace Raze.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [ApiController]
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

        [SwaggerOperation(
            Summary = "Get All Posts",
            Description = "Get All Posts already stored.",
            Tags = new []{"Posts"})]
        
        [HttpGet]
        public async Task<IEnumerable<PostResource>> GetAllAsync()
        {
            var posts = await _postService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<PostResource> GetByIdAsync(int id)
        {
            var post = await _postService.FindByIdAsync(id);
            var resource = _mapper.Map<Post, PostResource>(post);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePostResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var post = _mapper.Map<SavePostResource, Post>(resource);
            var result = await _postService.SaveAsync(post);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var postResource = _mapper.Map<Post, PostResource>(result.Resource);
            return Ok(postResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePostResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var post = _mapper.Map<SavePostResource, Post>(resource);
            var result = await _postService.UpdateAsync(id, post);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var postResource = _mapper.Map<Post, PostResource>(result.Resource);
            return Ok(postResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _postService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var postResource = _mapper.Map<Post, PostResource>(result.Resource);
            return Ok(postResource);
        }
    }
}