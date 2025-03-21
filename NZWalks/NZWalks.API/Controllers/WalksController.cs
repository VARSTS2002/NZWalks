using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly NZWalksDbContext nZWalksDbContext;
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(NZWalksDbContext nZWalksDbContext, IWalkRepository walkRepository, IMapper mapper)
        {
            this.nZWalksDbContext = nZWalksDbContext;
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetActionAsync()
        {
            var walks = await walkRepository.GetAllAsync();
            return Ok(walks);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var walks = await walkRepository.GetByIdAsync(id);
            if (walks == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walks));
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddWalkDto addWalkDto)
        {
            var walk = mapper.Map<Models.Domain.Walk>(addWalkDto);
            walk = await walkRepository.AddWalkAsync(walk);
            var walkDto = mapper.Map<WalkDto>(walk);
            return Ok(walkDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid id,[FromBody] UpdateWalkDto updateWalkDto)
        {
            var walk = mapper.Map<Walk>(updateWalkDto);
            walk = await walkRepository.UpdateAsync(id, walk);
            if (walk == null)
            {
                return NotFound();
            }
            var walkDto = mapper.Map<WalkDto>(walk);
            return Ok(walkDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var walk = await walkRepository.DeleteAsync(id);
            if (walk == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walk));
        }
    }
}
