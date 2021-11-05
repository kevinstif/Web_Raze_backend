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
    [Route("api/v1/tags/{tagId}/posts")]
    public class TagPostsController
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public TagPostsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PostResource>> GetAllByTag(int tagId)
        {
            var posts = await _postService.ListByTagAsync(tagId);
            var resources = _mapper.Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);

            return resources;
        }
    }
}