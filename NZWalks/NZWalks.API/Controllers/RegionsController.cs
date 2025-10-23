using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Repositories;
using AutoMapper;
using NZWalks.API.CustomActionFilters;

namespace NZWalks.API.Controllers
{
    // https://localhost:port/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        
        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }
        

        // GET: api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await _regionRepository.GetAllAsync();

            // Return DTOs
            return Ok(_mapper.Map<List<Models.DTO.RegionDto>>(regionsDomain));
        }

        // GET: api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Get Region Domain model from database
            var regionDomain = await _regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            // Return DTO
            return Ok(_mapper.Map<Models.DTO.RegionDto>(regionDomain));
        }

        // POST TO Create new region
        // POST: api/regions
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map DTO to Domain model
            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);

            // Use Domain Model to create region in database
            regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);

            if (regionDomainModel == null)
            {
                return BadRequest();
            }

            // Map Domain model back to DTO
            var regionDto = _mapper.Map<Models.DTO.RegionDto>(regionDomainModel);
            
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        // Update region
        // Put: api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] Models.DTO.UpdateRegionRequestDto updateRegionRequestDto)
        {
            // Map DTO to Domain model
            var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDto);

            // Use Domain Model to update region in database
            regionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // Return updated DTO
            return Ok(_mapper.Map<Models.DTO.RegionDto>(regionDomainModel));
        }

        // Delete region
        // DELETE: api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // Check if region exists
            var regionDomainModel = await _regionRepository.DeleteAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // Return deleted region
            return Ok(_mapper.Map<Models.DTO.RegionDto>(regionDomainModel));
        }
    }
}
