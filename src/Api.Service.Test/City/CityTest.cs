using System;
using System.Collections.Generic;
using Api.Domain.Dtos.City;
using Api.Domain.Dtos.State;

namespace Api.Service.Test.City
{
    public class CityTest
    {
        public static string NameCity { get; set; }
        public static int CodeIBGECity { get; set; }
        public static string NameCityChanged { get; set; }
        public static int CodeIBGECityChanged { get; set; }
        public static Guid CityId { get; set; }
        public static Guid StateId { get; set; }

        public List<CityDto> listDto = new List<CityDto>();
        public CityDto cityDto;
        public CityDtoComplete cityDtoComplete;
        public CityDtoCreate cityDtoCreate;
        public CityDtoCreateResult cityDtoCreateResult;
        public CityDtoUpdate cityDtoUpdate;
        public CityDtoUpdateResult cityDtoUpdateResult;

        public CityTest()
        {
            CityId = Guid.NewGuid();
            NameCity = Faker.Address.StreetName();
            CodeIBGECity = Faker.RandomNumber.Next(1, 10000);
            NameCityChanged = Faker.Address.StreetName();
            CodeIBGECityChanged = Faker.RandomNumber.Next(1, 10000);
            StateId = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var dto = new CityDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    StateId = Guid.NewGuid()
                };
                listDto.Add(dto);
            }

            cityDto = new CityDto
            {
                Id = CityId,
                Name = NameCity,
                CodIBGE = CodeIBGECity,
                StateId = StateId
            };

            cityDtoComplete = new CityDtoComplete
            {
                Id = CityId,
                Name = NameCity,
                CodIBGE = CodeIBGECity,
                StateId = StateId,
                State = new StateDto
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Address.UsState(),
                    Initial = Faker.Address.UsState().Substring(1, 3)
                }
            };

            cityDtoCreate = new CityDtoCreate
            {
                Name = NameCity,
                CodIBGE = CodeIBGECity,
                StateId = StateId
            };

            cityDtoCreateResult = new CityDtoCreateResult
            {
                Id = CityId,
                Name = NameCity,
                CodIBGE = CodeIBGECity,
                StateId = StateId,
                CreatedAt = DateTime.UtcNow
            };

            cityDtoUpdate = new CityDtoUpdate
            {
                Id = CityId,
                Name = NameCityChanged,
                CodIBGE = CodeIBGECityChanged,
                StateId = StateId
            };

            cityDtoUpdateResult = new CityDtoUpdateResult
            {
                Id = CityId,
                Name = NameCityChanged,
                CodIBGE = CodeIBGECityChanged,
                StateId = StateId,
                UpdatedAt = DateTime.UtcNow
            };

        }
    }
}
