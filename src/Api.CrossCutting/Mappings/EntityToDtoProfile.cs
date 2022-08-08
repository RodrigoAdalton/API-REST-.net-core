using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.City;
using Api.Domain.Dtos.State;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
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


            CreateMap<StateDto, StateEntity>()
               .ReverseMap();


            CreateMap<CityDto, CityEntity>()
               .ReverseMap();

            CreateMap<CityDtoComplete, CityEntity>()
               .ReverseMap();

            CreateMap<CityDtoCreateResult, CityEntity>()
               .ReverseMap();

            CreateMap<CityDtoUpdateResult, CityEntity>()
               .ReverseMap();


            CreateMap<CepDto, CepEntity>()
               .ReverseMap();

            CreateMap<CepDtoCreateResult, CepEntity>()
               .ReverseMap();

            CreateMap<CepDtoUpdateResult, CepEntity>()
               .ReverseMap();

        }
    }
}
