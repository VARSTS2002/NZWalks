using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public WalkRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Walk> AddWalkAsync(Walk walk)
        {
            walk.Id = new Guid();
            await nZWalksDbContext.Walks.AddAsync(walk);
            await nZWalksDbContext.SaveChangesAsync();
            return walk;

        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var walk = await nZWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walk == null)
            {
                return null;
            }
            nZWalksDbContext.Walks.Remove(walk);
            await nZWalksDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return nZWalksDbContext.Walks.Include("WalkDifficulty").Include("Region").ToList();
        }

        public async Task<Walk>  GetByIdAsync(Guid id)
        {
            var walks = nZWalksDbContext.Walks.Include("WalkDifficulty").Include("Region").FirstOrDefault(x => x.Id == id);
            if (walks == null)
            {
                return null;
            }
            return walks;
        }

       
        public async Task<Walk?> UpdateAsync(Guid Id, Walk walk)
        {
            var walks = await nZWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == Id);
            
            if (walks == null)
            {
                return null;
            }
            walks.Name = walk.Name;
            walks.Length = walk.Length;
            walks.RegionId = walk.RegionId;
            walks.WalkDifficultyId = walk.WalkDifficultyId;

            await nZWalksDbContext.SaveChangesAsync();
            return walks;
        }
    }
}
