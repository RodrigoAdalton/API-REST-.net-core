using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.City;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class CityMapper : BaseTestService
    {
        [Fact(DisplayName = "É Possível Mapear os Modelo de City")]
        public void E_Possivel_Mapear_os_Modelos_City()
        {
            var model = new CityModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1, 10000),
                StateId = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var listaEntity = new List<CityEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new CityEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    StateId = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    State = new StateEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Address.UsState(),
                        Initial = Faker.Address.UsState().Substring(1, 3)
                    }
                };
                listaEntity.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<CityEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.CodIBGE, model.CodIBGE);
            Assert.Equal(entity.StateId, model.StateId);
            Assert.Equal(entity.CreatedAt, model.CreatedAt);
            Assert.Equal(entity.UpdatedAt, model.UpdatedAt);

            //Entity para Dto
            var userDto = Mapper.Map<CityDto>(entity);
            Assert.Equal(userDto.Id, entity.Id);
            Assert.Equal(userDto.Name, entity.Name);
            Assert.Equal(userDto.CodIBGE, entity.CodIBGE);
            Assert.Equal(userDto.StateId, entity.StateId);

            var userDtoCompleto = Mapper.Map<CityDtoComplete>(listaEntity.FirstOrDefault());
            Assert.Equal(userDtoCompleto.Id, listaEntity.FirstOrDefault().Id);
            Assert.Equal(userDtoCompleto.Name, listaEntity.FirstOrDefault().Name);
            Assert.Equal(userDtoCompleto.CodIBGE, listaEntity.FirstOrDefault().CodIBGE);
            Assert.Equal(userDtoCompleto.StateId, listaEntity.FirstOrDefault().StateId);
            Assert.NotNull(userDtoCompleto.State);

            var listaDto = Mapper.Map<List<CityDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Name, listaEntity[i].Name);
                Assert.Equal(listaDto[i].CodIBGE, listaEntity[i].CodIBGE);
                Assert.Equal(listaDto[i].StateId, listaEntity[i].StateId);
            }

            var userDtoCreateResult = Mapper.Map<CityDtoCreateResult>(entity);
            Assert.Equal(userDtoCreateResult.Id, entity.Id);
            Assert.Equal(userDtoCreateResult.Name, entity.Name);
            Assert.Equal(userDtoCreateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(userDtoCreateResult.StateId, entity.StateId);
            Assert.Equal(userDtoCreateResult.CreatedAt, entity.CreatedAt);

            var userDtoUpdateResult = Mapper.Map<CityDtoUpdateResult>(entity);
            Assert.Equal(userDtoUpdateResult.Id, entity.Id);
            Assert.Equal(userDtoUpdateResult.Name, entity.Name);
            Assert.Equal(userDtoUpdateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(userDtoCreateResult.StateId, entity.StateId);
            Assert.Equal(userDtoUpdateResult.UpdatedAt, entity.UpdatedAt);

            //Dto para Model
            var userModel = Mapper.Map<CityModel>(userDto);
            Assert.Equal(userModel.Id, userDto.Id);
            Assert.Equal(userModel.Name, userDto.Name);
            Assert.Equal(userModel.CodIBGE, userDto.CodIBGE);
            Assert.Equal(userModel.StateId, userDto.StateId);

            var userDtoCreate = Mapper.Map<CityDtoCreate>(userModel);
            Assert.Equal(userDtoCreate.Name, userModel.Name);
            Assert.Equal(userDtoCreate.CodIBGE, userModel.CodIBGE);
            Assert.Equal(userDtoCreate.StateId, userModel.StateId);

            var userDtoUpdate = Mapper.Map<CityDtoUpdate>(userModel);
            Assert.Equal(userDtoUpdate.Id, userModel.Id);
            Assert.Equal(userDtoUpdate.Name, userModel.Name);
            Assert.Equal(userDtoUpdate.CodIBGE, userModel.CodIBGE);
            Assert.Equal(userDtoUpdate.StateId, userModel.StateId);

        }
    }
}
