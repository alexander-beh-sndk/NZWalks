using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;

namespace NZWalks.API.Repositories
{
    public class InMemoryRegionRepository : IRegionRepository
    {
        public async Task<List<Models.Domain.Region>> GetAllAsync()
        {
            return new List<Models.Domain.Region>()
            {
                new Models.Domain.Region()
                {
                    Id = Guid.NewGuid(),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://example.com/auckland.jpg"
                }
            };
        }


    }

}
