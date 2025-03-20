using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid Id);
        Task<Region> AddAsync(Region region);
        Task<Region> DeleteAsync(Guid Id);
        Task<Region> UpdateAsync(Guid id,Region region);

    }
}
