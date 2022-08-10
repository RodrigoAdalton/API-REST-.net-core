using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.City;
using Api.Domain.Dtos.State;

namespace Api.Service.Test.Cep
{
    public class CepTest
    {
        public static string CepOriginal { get; set; }
        public static string AddressOriginal { get; set; }
        public static string NumberOriginal { get; set; }
        public static string CepChanged { get; set; }
        public static string AddressChanged { get; set; }
        public static string NumberChanged { get; set; }
        public static Guid CityId { get; set; }
        public static Guid CepId { get; set; }

        public List<CepDto> listDto = new List<CepDto>();
        public CepDto cepDto;
        public CepDtoCreate cepDtoCreate;
        public CepDtoCreateResult cepDtoCreateResult;
        public CepDtoUpdate cepDtoUpdate;
        public CepDtoUpdateResult cepDtoUpdateResult;

        public CepTest()
        {
            CityId = Guid.NewGuid();
            CepId = Guid.NewGuid();
            CepOriginal = Faker.RandomNumber.Next(10000, 99999).ToString();
            NumberOriginal = Faker.RandomNumber.Next(1, 1000).ToString();
            AddressOriginal = Faker.Address.StreetName();
            CepChanged = Faker.RandomNumber.Next(10000, 99999).ToString();
            NumberChanged = Faker.RandomNumber.Next(1, 1000).ToString();
            AddressChanged = Faker.Address.StreetName();

            for (int i = 0; i < 10; i++)
            {
                var dto = new CepDto()
                {
                    Id = Guid.NewGuid(),
                    Cep = Faker.RandomNumber.Next(10000, 99999).ToString(),
                    Address = Faker.Address.StreetName(),
                    Number = Faker.RandomNumber.Next(1, 1000).ToString(),
                    CityId = Guid.NewGuid(),
                    City = new CityDtoComplete
                    {
                        Id = CityId,
                        Name = Faker.Address.City(),
                        CodIBGE = Faker.RandomNumber.Next(1, 10000),
                        StateId = Guid.NewGuid(),
                        State = new StateDto
                        {
                            Id = Guid.NewGuid(),
                            Name = Faker.Address.UsState(),
                            Initial = Faker.Address.UsState().Substring(1, 3)
                        }
                    }
                };
                listDto.Add(dto);
            }

            cepDto = new CepDto
            {
                Id = CepId,
                Cep = CepOriginal,
                Address = AddressOriginal,
                Number = NumberOriginal,
                CityId = CityId,
                City = new CityDtoComplete
                {
                    Id = CityId,
                    Name = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    StateId = Guid.NewGuid(),
                    State = new StateDto
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Address.UsState(),
                        Initial = Faker.Address.UsState().Substring(1, 3)
                    }
                }
            };

            cepDtoCreate = new CepDtoCreate
            {
                Cep = CepOriginal,
                Address = AddressOriginal,
                Number = NumberOriginal,
                CityId = CityId,
            };

            cepDtoCreateResult = new CepDtoCreateResult
            {
                Id = CepId,
                Cep = CepOriginal,
                Address = AddressOriginal,
                Number = NumberOriginal,
                CityId = CityId,
                CreatedAt = DateTime.UtcNow
            };

            cepDtoUpdate = new CepDtoUpdate
            {
                Id = CepId,
                Cep = CepChanged,
                Address = AddressChanged,
                Number = NumberChanged,
                CityId = CityId
            };

            cepDtoUpdateResult = new CepDtoUpdateResult
            {
                Id = CityId,
                Cep = CepChanged,
                Address = AddressChanged,
                Number = NumberChanged,
                CityId = CityId,
                UpdatedAt = DateTime.UtcNow
            };

        }
    }
}
