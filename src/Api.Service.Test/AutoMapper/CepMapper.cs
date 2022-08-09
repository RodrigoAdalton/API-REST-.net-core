using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Cep;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class CepMapper : BaseTestService
    {
        [Fact(DisplayName = "É Possível Mapear os Modelo de Cep")]
        public void E_Possivel_Mapear_os_Modelos_Cep()
        {
            var model = new CepModel
            {
                Id = Guid.NewGuid(),
                Cep = Faker.RandomNumber.Next(1, 10000).ToString(),
                Address = Faker.Address.StreetName(),
                Number = "",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CityId = Guid.NewGuid()
            };

            var listaEntity = new List<CepEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new CepEntity
                {
                    Id = Guid.NewGuid(),
                    Cep = Faker.RandomNumber.Next(1, 10000).ToString(),
                    Address = Faker.Address.StreetName(),
                    Number = Faker.RandomNumber.Next(1, 10000).ToString(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CityId = Guid.NewGuid(),
                    City = new CityEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Address.UsState(),
                        CodIBGE = Faker.RandomNumber.Next(1, 10000),
                        StateId = Guid.NewGuid(),
                        State = new StateEntity
                        {
                            Id = Guid.NewGuid(),
                            Name = Faker.Address.UsState(),
                            Initial = Faker.Address.UsState().Substring(1, 3)
                        }
                    }
                };
                listaEntity.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<CepEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Address, model.Address);
            Assert.Equal(entity.Number, model.Number);
            Assert.Equal(entity.Cep, model.Cep);
            Assert.Equal(entity.CreatedAt, model.CreatedAt);
            Assert.Equal(entity.UpdatedAt, model.UpdatedAt);

            //Entity para Dto
            var cepDto = Mapper.Map<CepDto>(entity);
            Assert.Equal(cepDto.Id, entity.Id);
            Assert.Equal(cepDto.Address, entity.Address);
            Assert.Equal(cepDto.Number, entity.Number);
            Assert.Equal(cepDto.Cep, entity.Cep);

            var cepDtoCompleto = Mapper.Map<CepDto>(listaEntity.FirstOrDefault());
            Assert.Equal(cepDtoCompleto.Id, listaEntity.FirstOrDefault().Id);
            Assert.Equal(cepDtoCompleto.Cep, listaEntity.FirstOrDefault().Cep);
            Assert.Equal(cepDtoCompleto.Address, listaEntity.FirstOrDefault().Address);
            Assert.Equal(cepDtoCompleto.Number, listaEntity.FirstOrDefault().Number);
            Assert.NotNull(cepDtoCompleto.City);
            Assert.NotNull(cepDtoCompleto.City.State);

            var listaDto = Mapper.Map<List<CepDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Cep, listaEntity[i].Cep);
                Assert.Equal(listaDto[i].Address, listaEntity[i].Address);
                Assert.Equal(listaDto[i].Number, listaEntity[i].Number);
            }

            var cepDtoCreateResult = Mapper.Map<CepDtoCreateResult>(entity);
            Assert.Equal(cepDtoCreateResult.Id, entity.Id);
            Assert.Equal(cepDtoCreateResult.Cep, entity.Cep);
            Assert.Equal(cepDtoCreateResult.Address, entity.Address);
            Assert.Equal(cepDtoCreateResult.Number, entity.Number);
            Assert.Equal(cepDtoCreateResult.CreatedAt, entity.CreatedAt);

            var cepDtoUpdateResult = Mapper.Map<CepDtoUpdateResult>(entity);
            Assert.Equal(cepDtoUpdateResult.Id, entity.Id);
            Assert.Equal(cepDtoUpdateResult.Cep, entity.Cep);
            Assert.Equal(cepDtoUpdateResult.Address, entity.Address);
            Assert.Equal(cepDtoCreateResult.Number, entity.Number);
            Assert.Equal(cepDtoUpdateResult.UpdatedAt, entity.UpdatedAt);

            //Dto para Model
            cepDto.Number = "";
            var cepModel = Mapper.Map<CepModel>(cepDto);
            Assert.Equal(cepModel.Id, cepDto.Id);
            Assert.Equal(cepModel.Cep, cepDto.Cep);
            Assert.Equal(cepModel.Address, cepDto.Address);
            Assert.Equal("S/N", cepModel.Number);

            var cepDtoCreate = Mapper.Map<CepDtoCreate>(cepModel);
            Assert.Equal(cepDtoCreate.Cep, cepModel.Cep);
            Assert.Equal(cepDtoCreate.Address, cepModel.Address);
            Assert.Equal(cepDtoCreate.Number, cepModel.Number);

            var cepDtoUpdate = Mapper.Map<CepDtoUpdate>(cepModel);
            Assert.Equal(cepDtoUpdate.Id, cepModel.Id);
            Assert.Equal(cepDtoUpdate.Cep, cepModel.Cep);
            Assert.Equal(cepDtoUpdate.Address, cepModel.Address);
            Assert.Equal(cepDtoUpdate.Number, cepModel.Number);

        }
    }
}
