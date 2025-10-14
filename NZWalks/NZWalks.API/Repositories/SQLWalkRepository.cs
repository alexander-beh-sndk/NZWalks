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
            return await _dbContext.Walks.ToListAsync();
        }
    }
}
