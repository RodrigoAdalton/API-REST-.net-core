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
    public class CepCompleteCrud : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public CepCompleteCrud(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }


        [Fact(DisplayName = "CRUD de Cep")]
        [Trait("CRUD", "CepEntity")]
        public async Task E_Possivel_Realizar_CRUD_Cep()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                CityImplementation _repositorioCity = new CityImplementation(context);
                CityEntity _entityCity = new CityEntity
                {
                    Name = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1000000, 9999999),
                    StateId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
                };

                var _registroCriado = await _repositorioCity.InsertAsync(_entityCity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entityCity.Name, _registroCriado.Name);
                Assert.Equal(_entityCity.CodIBGE, _registroCriado.CodIBGE);
                Assert.Equal(_entityCity.StateId, _registroCriado.StateId);
                Assert.False(_registroCriado.Id == Guid.Empty);

                CepImplementation _repositorio = new CepImplementation(context);
                CepEntity _entityCep = new CepEntity
                {
                    Cep = "13.481-001",
                    Address = Faker.Address.StreetName(),
                    Number = "0 até 2000",
                    CityId = _registroCriado.Id
                };

                var _registroCriadoCep = await _repositorio.InsertAsync(_entityCep);
                Assert.NotNull(_registroCriadoCep);
                Assert.Equal(_entityCep.Cep, _registroCriadoCep.Cep);
                Assert.Equal(_entityCep.Address, _registroCriadoCep.Address);
                Assert.Equal(_entityCep.Number, _registroCriadoCep.Number);
                Assert.Equal(_entityCep.CityId, _registroCriadoCep.CityId);
                Assert.False(_registroCriadoCep.Id == Guid.Empty);

                _entityCep.Address = Faker.Address.StreetName();
                _entityCep.Id = _registroCriadoCep.Id;
                var _registroAtualizado = await _repositorio.UpdateAsync(_entityCep);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entityCep.Cep, _registroAtualizado.Cep);
                Assert.Equal(_entityCep.Address, _registroAtualizado.Address);
                Assert.Equal(_entityCep.CityId, _registroAtualizado.CityId);
                Assert.True(_registroCriadoCep.Id == _entityCep.Id);

                var _registroExiste = await _repositorio.ExistAsync(_registroAtualizado.Id);
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorio.SelectAsync(_registroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.Cep, _registroSelecionado.Cep);
                Assert.Equal(_registroAtualizado.Address, _registroSelecionado.Address);
                Assert.Equal(_registroAtualizado.Number, _registroSelecionado.Number);
                Assert.Equal(_registroAtualizado.CityId, _registroSelecionado.CityId);

                _registroSelecionado = await _repositorio.SelectAsync(_registroAtualizado.Cep);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.Cep, _registroSelecionado.Cep);
                Assert.Equal(_registroAtualizado.Address, _registroSelecionado.Address);
                Assert.Equal(_registroAtualizado.Number, _registroSelecionado.Number);
                Assert.Equal(_registroAtualizado.CityId, _registroSelecionado.CityId);
                Assert.NotNull(_registroSelecionado.City);
                Assert.Equal(_entityCity.Name, _registroSelecionado.City.Name);
                Assert.NotNull(_registroSelecionado.City.State);
                Assert.Equal("SP", _registroSelecionado.City.State.Initial);

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
