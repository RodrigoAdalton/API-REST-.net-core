using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.State;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class StateMapper : BaseTestService
    {
        [Fact(DisplayName = "É Possível Mapear os Modelos de State")]
        public void E_Possivel_Mapear_os_Modelos_State()
        {
            var model = new StateModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Address.UsState(),
                Initial = Faker.Address.UsState().Substring(1, 3),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var listaEntity = new List<StateEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new StateEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Address.UsState(),
                    Initial = Faker.Address.UsState().Substring(1, 3),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                listaEntity.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<StateEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.Initial, model.Initial);
            Assert.Equal(entity.CreatedAt, model.CreatedAt);
            Assert.Equal(entity.UpdatedAt, model.UpdatedAt);

            //Entity para Dto
            var stateDto = Mapper.Map<StateDto>(entity);
            Assert.Equal(stateDto.Id, entity.Id);
            Assert.Equal(stateDto.Name, entity.Name);
            Assert.Equal(stateDto.Initial, entity.Initial);

            var listaDto = Mapper.Map<List<StateDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Name, listaEntity[i].Name);
                Assert.Equal(listaDto[i].Initial, listaEntity[i].Initial);
            }

            //Dto para Model
            var userModel = Mapper.Map<StateDto>(model);
            Assert.Equal(userModel.Id, model.Id);
            Assert.Equal(userModel.Name, model.Name);
            Assert.Equal(userModel.Initial, model.Initial);

        }
    }
}
