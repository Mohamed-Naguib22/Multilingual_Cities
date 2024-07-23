using AutoMapper;
using Multilingual.Dtos;
using Multilingual.Entities;

namespace Multilingual.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, GetCityDto>().ReverseMap();
        }
    }
}
