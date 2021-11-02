using api.domain.Dtos.User;
using api.domain.Models;
using AutoMapper;

namespace api.crosscutting.Mapping
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModels, UserDto>()
                .ReverseMap();
            CreateMap<UserModels, UserDtoCreate>()
           .ReverseMap();
            CreateMap<UserModels, UserDtoUpdate>()
           .ReverseMap();
        }
    }
}
