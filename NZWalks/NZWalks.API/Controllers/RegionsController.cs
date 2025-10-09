using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Controllers
{
    // https://localhost:port/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        // GET: api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = new List<Region>
            {
                new Region 
                { 
                    Id = Guid.NewGuid(), 
                    Name = "Auckland Region", 
                    Code = "AKL", 
                    RegionImageUrl = "https://www.pexels.com/photo/view-of-river-572689/"
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Wallington Region",
                    Code = "WLG",
                    RegionImageUrl = "https://www.pexels.com/photo/brown-and-orange-house-with-outdoor-plants-2259917/"
                },
            };

            return Ok(regions);
        }
    }
}
