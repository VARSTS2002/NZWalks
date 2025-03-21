using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public interface IWalkRepository
    {

        Task<List<Walk>> GetAllAsync();
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk> AddWalkAsync(Walk walk);
        Task<Walk?> UpdateAsync( Guid id, Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
