using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using System.Runtime.CompilerServices;

namespace NZWalks.API.Controllers
{
    //  api/Walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly NZWalks.API.Repositories.IWalkRepository _walkRepository;
        public WalksController(IMapper mapper, NZWalks.API.Repositories.IWalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }

        // Create a Walk
        // Post: api/Walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            // map DTO to Domain model
            var walkDomainModel = _mapper.Map<NZWalks.API.Models.Domain.Walk>(addWalkRequestDto);

            await _walkRepository.CreateAsync(walkDomainModel);

            // Map Domain model to DTO
            return Ok(_mapper.Map<Models.DTO.WalkDto>(walkDomainModel));
        }

        // Get all Walks
        // GET: api/Walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await _walkRepository.GetAllAsync();

            // Map Domain model to DTO
            return Ok(_mapper.Map<List<Models.DTO.WalkDto>>(walksDomainModel));
        }

        // Get Walk by Id
        // GET: api/Walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await _walkRepository.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
           
            // Map Domain model to DTO
            return Ok(_mapper.Map<Models.DTO.WalkDto>(walkDomainModel));
        }

        // Update Walk
        // Put: api/Walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            // Map DTO to Domain model
            var walkDomainModel = _mapper.Map<NZWalks.API.Models.Domain.Walk>(updateWalkRequestDto);
            
            // Use Domain Model to update walk in database
            walkDomainModel = await _walkRepository.UpdateAsync(id, walkDomainModel);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            
            // Map Domain model back to DTO
            return Ok(_mapper.Map<Models.DTO.WalkDto>(walkDomainModel));
        }

        // Delete Walk
        // DELETE: api/Walks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // Check if walk exists
            var walkDomainModel = await _walkRepository.DeleteAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            // Return deleted walk
            return Ok(_mapper.Map<Models.DTO.WalkDto>(walkDomainModel));
        }
    }
}
