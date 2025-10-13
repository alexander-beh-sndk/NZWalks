using AutoMapper;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Models.Domain.Region, Models.DTO.RegionDto>().ReverseMap();
            CreateMap<Models.DTO.AddRegionRequestDto, Models.Domain.Region>().ReverseMap();
            CreateMap<Models.DTO.UpdateRegionRequestDto, Models.Domain.Region>().ReverseMap();
        }
    }
}
