using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;

namespace NZWalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _dbContext;
        
        public SQLRegionRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Models.Domain.Region>> GetAllAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        public async Task<Models.Domain.Region?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Models.Domain.Region?> CreateAsync(Models.Domain.Region region)
        {
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Models.Domain.Region?> UpdateAsync(Guid id, Models.Domain.Region region)
        {
            var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await _dbContext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<Models.Domain.Region?> DeleteAsync(Guid id)
        {
            // Check if region exists
            var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }

            // Delete region
            _dbContext.Regions.Remove(existingRegion);
            await _dbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
