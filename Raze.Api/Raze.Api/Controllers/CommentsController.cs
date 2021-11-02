using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services;
using Raze.Api.Extensions;
using Raze.Api.Resources.CommentResources;

namespace Raze.Api.Controllers
{
    [Route("/api/v1/[controller]")]
    public class CommentsController: ControllerBase
    {
        private readonly ICommentServices _commentServices;
        private readonly IMapper _mapper;

        public CommentsController(ICommentServices commentServices, IMapper mapper)
        {
            _commentServices = commentServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CommentResource>> GetAllAsync()
        {
            var comments = await _commentServices.ListAsync();

            var resources = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentResource>>(comments);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<CommentResource> GetByIdAsync(int id)
        {
            var comment = await _commentServices.FindByIdAsync(id);
            var resource = _mapper.Map<Comment, CommentResource>(comment);

            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCommentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var comment = _mapper.Map<SaveCommentResource, Comment>(resource);
            var result = await _commentServices.SaveAsync(comment);

            if (!result.Success)
                return BadRequest(result.Message);

            var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);

            return Ok(commentResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveCommentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var comment = _mapper.Map<SaveCommentResource, Comment>(resource);
            var result = await _commentServices.UpdateAsync(id,comment);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);
            return Ok(commentResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _commentServices.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);
            return Ok(commentResource);
        }
    }
}