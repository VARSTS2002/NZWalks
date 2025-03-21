using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public interface IWalkDifficultyRepository
    {
        Task<List<WalkDifficulty>> GetAllAsync();
        Task<WalkDifficulty> GetByIdAsync(Guid id);
        Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty);
        Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDifficulty);
        Task<WalkDifficulty> DeleteAsync(Guid id);
    }
}
