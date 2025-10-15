using NZWalks.API.Data;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Models.Domain.Walk> CreateAsync(Models.Domain.Walk walk)
        {
            await _dbContext.Walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Models.Domain.Walk>> GetAllAsync()
        {
            return await _dbContext.Walks.Include(w => w.Difficulty).Include(w => w.Region).ToListAsync();
        }

        public async Task<Models.Domain.Walk?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Walks.Include(w => w.Difficulty).Include(w => w.Region).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Models.Domain.Walk?> UpdateAsync(Guid id, Models.Domain.Walk walk)
        {
            var existingWalk = await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }
            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.DifficultyId = walk.DifficultyId;
            await _dbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<Models.Domain.Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }
            _dbContext.Walks.Remove(existingWalk);
            await _dbContext.SaveChangesAsync();
            return existingWalk;
        }
    }
}
