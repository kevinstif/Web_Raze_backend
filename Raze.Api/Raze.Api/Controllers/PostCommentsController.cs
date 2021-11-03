using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services;
using Raze.Api.Resources.CommentResources;

namespace Raze.Api.Controllers
{
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
        public async Task<IEnumerable<CommentResource>> GetAllByPostIdAsync(int postId)
        {
            var comments = await _commentServices.LisByPostAsync(postId);
            var resources = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentResource>>(comments);

            return resources;
        }
    }
}