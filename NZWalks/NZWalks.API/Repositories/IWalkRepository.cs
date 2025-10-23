namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Models.Domain.Walk> CreateAsync(Models.Domain.Walk walk);

        Task<List<Models.Domain.Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, 
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 1000);

        Task<Models.Domain.Walk?> GetByIdAsync(Guid id);

        Task<Models.Domain.Walk?> UpdateAsync(Guid id, Models.Domain.Walk walk);

        Task<Models.Domain.Walk?> DeleteAsync(Guid id);
    }
}
