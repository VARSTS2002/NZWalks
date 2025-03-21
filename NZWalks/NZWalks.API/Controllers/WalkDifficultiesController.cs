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
    public class WalkDifficultiesController : ControllerBase
    {
        private readonly NZWalksDbContext nZWalksDbContext;
        private readonly IMapper mapper;
        private readonly IWalkDifficultyRepository walkDifficultyRepository;

        public WalkDifficultiesController(NZWalksDbContext nZWalksDbContext,IMapper mapper,IWalkDifficultyRepository walkDifficultyRepository)
        {
            this.nZWalksDbContext = nZWalksDbContext;
            this.mapper = mapper;
            this.walkDifficultyRepository = walkDifficultyRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walkDifficulty = await walkDifficultyRepository.GetAllAsync();
            return Ok(walkDifficulty);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var walkDifficulty = await walkDifficultyRepository.GetByIdAsync(id);
            if (walkDifficulty == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDifficultyDto>(walkDifficulty));
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update(Guid id,UpdateWalkDifficultyDto updateWalkDifficultyDto)
        {
            var walkDifficulty = mapper.Map<WalkDifficulty>(updateWalkDifficultyDto);
            walkDifficulty = await walkDifficultyRepository.UpdateAsync(id, walkDifficulty);
            if (walkDifficulty == null)
            {
                return NotFound();
            }
            var WalkDifficultyDto = mapper.Map<WalkDifficultyDto>(walkDifficulty);
            return Ok(WalkDifficultyDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddWalkDifficultyDto addWalkDifficultyDto)
        {
            var walkDifficultyDomain = mapper.Map<WalkDifficulty>(addWalkDifficultyDto);
            walkDifficultyDomain = await walkDifficultyRepository.AddAsync(walkDifficultyDomain);
            return Ok(mapper.Map<WalkDifficultyDto>(walkDifficultyDomain));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDifficulty = await walkDifficultyRepository.DeleteAsync(id);
            if (walkDifficulty == null)
            {
                return NotFound();
            }
            return Ok(walkDifficulty);
        }
    }
}
