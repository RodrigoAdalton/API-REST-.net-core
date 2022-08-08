using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.City;
using Api.Domain.Dtos.State;
using Api.Domain.Dtos.User;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {

        public DtoToModelProfile()
        {
            #region User
            CreateMap<UserModel, UserDto>()
                .ReverseMap();

            CreateMap<UserModel, UserDtoCreate>()
                .ReverseMap();

            CreateMap<UserModel, UserDtoUpdate>()
                .ReverseMap();
            #endregion

            #region State
            CreateMap<StateModel, StateDto>()
                .ReverseMap();
            #endregion

            #region City
            CreateMap<CityModel, CityDto>()
                .ReverseMap();
            CreateMap<CityModel, CityDtoCreate>()
                .ReverseMap();
            CreateMap<CityModel, CityDtoUpdate>()
                .ReverseMap();
            #endregion

            #region CEP
            CreateMap<CepModel, CepDto>()
                .ReverseMap();
            CreateMap<CepModel, CepDtoCreate>()
                .ReverseMap();
            CreateMap<CepModel, CepDtoUpdate>()
                .ReverseMap();
            #endregion
        }

    }
}
