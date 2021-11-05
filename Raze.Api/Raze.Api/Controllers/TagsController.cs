using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services;
using Raze.Api.Extensions;
using Raze.Api.Resources;

namespace Raze.Api.Controllers
{
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

        [HttpGet]
        public async Task<IEnumerable<TagResource>> GetAllAsync()
        {
            var tags = await _tagServices.ListAsync();

            var resources = _mapper.Map<IEnumerable<Tag>, IEnumerable<TagResource>>(tags);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<TagResource> GetByIdAsync(int id)
        {
            var tag = await _tagServices.FindByIdAsync(id);
            var resource = _mapper.Map<Tag, TagResource>(tag);
            return resource;
        }

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