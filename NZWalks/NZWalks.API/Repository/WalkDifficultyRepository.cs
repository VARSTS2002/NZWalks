using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public WalkDifficultyRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = new Guid();
            await nZWalksDbContext.WalkDifficulties.AddAsync(walkDifficulty);
            await nZWalksDbContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var walkDiffculty = await nZWalksDbContext.WalkDifficulties.FirstOrDefaultAsync(x => x.Id == id);
            if (walkDiffculty == null)
            {
                return null;
            }
            nZWalksDbContext.WalkDifficulties.Remove(walkDiffculty);
            await nZWalksDbContext.SaveChangesAsync();
            return walkDiffculty;
        }

        public async Task<List<WalkDifficulty>> GetAllAsync()
        {
            return await nZWalksDbContext.WalkDifficulties.ToListAsync();
        }

        public async Task<WalkDifficulty> GetByIdAsync(Guid id)
        {
            var walkDifficulty = await nZWalksDbContext.WalkDifficulties.FirstOrDefaultAsync(x => x.Id == id);
            if (walkDifficulty == null)
            {
                return null;
            }
            return walkDifficulty;
        }

        public async Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            var walkDif = await nZWalksDbContext.WalkDifficulties.FirstOrDefaultAsync(x => x.Id == id);
            if (walkDif == null)
            {
                return null;
            }
            walkDif.Code = walkDifficulty.Code;
            await nZWalksDbContext.SaveChangesAsync();
            return walkDif;
        }
    }
}
