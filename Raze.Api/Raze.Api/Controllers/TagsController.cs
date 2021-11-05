using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services;
using Raze.Api.Extensions;
using Raze.Api.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace Raze.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class TagsController:ControllerBase
    {
        private readonly ITagServices _tagServices;
        private readonly IMapper _mapper;

        public TagsController(ITagServices tagServices, IMapper mapper)
        {
            _tagServices = tagServices;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "Get All Tags",
            Description = "Get All Tags already stored",
            Tags = new []{"Tags"})]
        [HttpGet]
        public async Task<IEnumerable<TagResource>> GetAllAsync()
        {
            var tags = await _tagServices.ListAsync();

            var resources = _mapper.Map<IEnumerable<Tag>, IEnumerable<TagResource>>(tags);

            return resources;
        }

        [SwaggerOperation(
            Summary = "Get Tag",
            Description = "Get Tag By Id already stored",
            Tags = new []{"Tag"})]
        [HttpGet("{id}")]
        public async Task<TagResource> GetByIdAsync(int id)
        {
            var tag = await _tagServices.FindByIdAsync(id);
            var resource = _mapper.Map<Tag, TagResource>(tag);
            return resource;
        }

        [SwaggerOperation(
            Summary = "Create Tag",
            Description = "Create Tag",
            Tags = new []{"Create"})]
        [HttpPost]
        public async Task<IActionResult> CreateTagAsync([FromBody] SaveTagResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var tag = _mapper.Map<SaveTagResource, Tag>(resource);
            var result = await _tagServices.SaveAsync(tag);

            if (!result.Success)
                return BadRequest(result.Message);

            var tagResource = _mapper.Map<Tag, TagResource>(result.Resource);

            return Ok(tagResource);
        }

        [SwaggerOperation(
            Summary = "Update Tag",
            Description = "Update Tag By Id already stored",
            Tags = new []{"Tag"})]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveTagResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var tag = _mapper.Map<SaveTagResource, Tag>(resource);
            var result = await _tagServices.UpdateAsync(id,tag);

            if (!result.Success)
                return BadRequest(result.Message);

            var tagResource = _mapper.Map<Tag, TagResource>(result.Resource);

            return Ok(tagResource);
        }

        [SwaggerOperation(
            Summary = "Delete Tag",
            Description = "Delete Tag By Id already stored",
            Tags = new []{"Tag"})]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _tagServices.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);
            
            var tagResource = _mapper.Map<Tag, TagResource>(result.Resource);
            return Ok(result.Resource);
        }
    }
}