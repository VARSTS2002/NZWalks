
using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Mapping

{
    public class AddAutoMappingProfile:Profile
    {
        public AddAutoMappingProfile()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
        }

    }
}
