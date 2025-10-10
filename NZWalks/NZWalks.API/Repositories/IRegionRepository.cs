namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Models.Domain.Region>> GetAllAsync();
        /*
        Task<Models.Domain.Region> GetByIdAsync(Guid id);
        Task<Models.Domain.Region> CreateAsync(Models.Domain.Region region);
        Task<Models.Domain.Region> UpdateAsync(Guid id, Models.Domain.Region region);
        Task<Models.Domain.Region> DeleteAsync(Guid id);
        */
    }
}
