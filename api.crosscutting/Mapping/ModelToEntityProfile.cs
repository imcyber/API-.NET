using api.domain.Entities;
using api.domain.Models;
using AutoMapper;

namespace api.crosscutting.Mapping
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModels>()
                .ReverseMap();
        }
    }
}
