using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class CityCompleteCrud : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public CityCompleteCrud(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de City")]
        [Trait("CRUD", "CityEntity")]
        public async Task E_Possivel_Realizar_CRUD_City()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {

                CityImplementation _repositorio = new CityImplementation(context);
                CityEntity _entity = new CityEntity
                {
                    Name = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1000000, 9999999),
                    StateId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.Equal(_entity.CodIBGE, _registroCriado.CodIBGE);
                Assert.Equal(_entity.StateId, _registroCriado.StateId);
                Assert.False(_registroCriado.Id == Guid.Empty);

                _entity.Name = Faker.Address.City();
                _entity.Id = _registroCriado.Id;
                var _registroAtualizado = await _repositorio.UpdateAsync(_entity);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entity.Name, _registroAtualizado.Name);
                Assert.Equal(_entity.CodIBGE, _registroAtualizado.CodIBGE);
                Assert.Equal(_entity.StateId, _registroAtualizado.StateId);
                Assert.True(_registroCriado.Id == _entity.Id);

                var _registroExiste = await _repositorio.ExistAsync(_registroAtualizado.Id);
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorio.SelectAsync(_registroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.Name, _registroSelecionado.Name);
                Assert.Equal(_registroAtualizado.CodIBGE, _registroSelecionado.CodIBGE);
                Assert.Equal(_registroAtualizado.StateId, _registroSelecionado.StateId);
                Assert.Null(_registroSelecionado.State);

                _registroSelecionado = await _repositorio.GetCompleteByIBGE(_registroAtualizado.CodIBGE);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.Name, _registroSelecionado.Name);
                Assert.Equal(_registroAtualizado.CodIBGE, _registroSelecionado.CodIBGE);
                Assert.Equal(_registroAtualizado.StateId, _registroSelecionado.StateId);
                Assert.NotNull(_registroSelecionado.State);

                _registroSelecionado = await _repositorio.GetCompleteById(_registroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.Name, _registroSelecionado.Name);
                Assert.Equal(_registroAtualizado.CodIBGE, _registroSelecionado.CodIBGE);
                Assert.Equal(_registroAtualizado.StateId, _registroSelecionado.StateId);
                Assert.NotNull(_registroSelecionado.State);

                var _todosRegistros = await _repositorio.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 0);

                var _removeu = await _repositorio.DeleteAsync(_registroSelecionado.Id);
                Assert.True(_removeu);

                _todosRegistros = await _repositorio.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() == 0);

            }
        }
    }
}
