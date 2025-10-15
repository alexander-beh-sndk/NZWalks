namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Models.Domain.Walk> CreateAsync(Models.Domain.Walk walk);
        Task<List<Models.Domain.Walk>> GetAllAsync();
        Task<Models.Domain.Walk?> GetByIdAsync(Guid id);
        
        /*     
        Task<Models.Domain.Walk> UpdateAsync(Guid id, Models.Domain.Walk walk);
        Task<Models.Domain.Walk> DeleteAsync(Guid id);
        */
    }
}
