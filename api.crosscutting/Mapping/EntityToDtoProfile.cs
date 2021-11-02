using api.domain.Dtos.User;
using api.domain.Entities;
using AutoMapper;

namespace api.crosscutting.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoCreateResult, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoUpdateResult, UserEntity>()
                .ReverseMap();
        }
    }
}
