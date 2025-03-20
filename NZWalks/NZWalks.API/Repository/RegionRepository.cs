using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public RegionRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = new Guid();
            await nZWalksDbContext.AddAsync(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid Id)
        {
            var region= await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            if(region==null)
            {
                return null;
            }
            nZWalksDbContext.Regions.Remove(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return nZWalksDbContext.Regions.ToList();
        }

        public async Task<Region?> GetByIdAsync(Guid Id)
        {
            return nZWalksDbContext.Regions.FirstOrDefault(x => x.Id == Id);
        }

        public async Task<Region> UpdateAsync(Guid Id, Region region)
        {
            var Existregion = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            if (Existregion == null)
            {
                return null;
            }
            Existregion.Code = region.Code;
            Existregion.Name = region.Name;
            Existregion.Area = region.Area;
            Existregion.Lat = region.Lat;
            Existregion.Long = region.Long;
            Existregion.Population = region.Population;
            await nZWalksDbContext.SaveChangesAsync();
            return Existregion;
        }

    }
}
