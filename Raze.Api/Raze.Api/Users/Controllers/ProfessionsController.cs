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
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ProfessionsController : ControllerBase
    {
        private readonly IProfessionService _professionService;
        private readonly IMapper _mapper;

        public ProfessionsController(IProfessionService professionService, IMapper mapper)
        {
            _professionService = professionService;
            _mapper = mapper;
        }
        
        [SwaggerOperation(
            Summary = "Get All Professions",
            Description = "Get All Professions already stored.",
            Tags = new []{"Professions"})]
        
        [HttpGet]
        public async Task<IEnumerable<ProfessionResource>> GetAllAsync()
        {
            var professions = await _professionService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Profession>, IEnumerable<ProfessionResource>>(professions);
            
            return resources;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProfessionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var profession = _mapper.Map<SaveProfessionResource, Profession>(resource);

            var result = await _professionService.SaveAsync(profession);

            if (!result.Success)
                return BadRequest(result.Message);

            var professionResource = _mapper.Map<Profession, ProfessionResource>(result.Resource);
            return Ok(professionResource);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProfessionResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var profession = _mapper.Map<SaveProfessionResource, Profession>(resource);

            var result = await _professionService.UpdateAsync(id, profession);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var professionResource = _mapper.Map<Profession, ProfessionResource>(result.Resource);
            return Ok(professionResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _professionService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var professionResource = _mapper.Map<Profession, ProfessionResource>(result.Resource);
            return Ok(professionResource);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _professionService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var professionResource = _mapper.Map<Profession, ProfessionResource>(result.Resource);
            return Ok(professionResource);
        }
    }
}