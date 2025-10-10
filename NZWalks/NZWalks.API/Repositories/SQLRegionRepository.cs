using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;

namespace NZWalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;
        
        public SQLRegionRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Models.Domain.Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        /*
        public Task<Models.Domain.Region> CreateAsync(Models.Domain.Region region)
        {
            throw new NotImplementedException();
        }
        public Task<Models.Domain.Region> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Domain.Region> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<Models.Domain.Region> UpdateAsync(Guid id, Models.Domain.Region region)
        {
            throw new NotImplementedException();
        }
        */
    }
}
