using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services;
using Raze.Api.Resources.CommentResources;
using Raze.Api.Security.Authorization.Attributes;
using Swashbuckle.AspNetCore.Annotations;

namespace Raze.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/posts/{postId}/comments")]
    public class PostCommentsController:ControllerBase
    {
        private readonly ICommentServices _commentServices;
        private readonly IMapper _mapper;

        public PostCommentsController(ICommentServices commentServices, IMapper mapper)
        {
            _commentServices = commentServices;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get All Comments By Post",
            Description = "Get All Comments for a the given PostId.",
            Tags = new []{"Comments"})]
        public async Task<IEnumerable<CommentResource>> GetAllByPostIdAsync(int postId)
        {
            var comments = await _commentServices.LisByPostAsync(postId);
            var resources = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentResource>>(comments);

            return resources;
        }
    }
}