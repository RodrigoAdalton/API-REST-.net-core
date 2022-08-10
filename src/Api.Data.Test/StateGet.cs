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
    public class StateGet : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public StateGet(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "Get de State")]
        [Trait("GET", "StateEntity")]
        public async Task E_Possivel_Realizar_Get_State()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                StateImplementation _repositorio = new StateImplementation(context);
                StateEntity _entity = new StateEntity
                {
                    Id = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                    Initial = "SP",
                    Name = "São Paulo"
                };

                var _registroExiste = await _repositorio.ExistAsync(_entity.Id);
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorio.SelectAsync(_entity.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_entity.Initial, _registroSelecionado.Initial);
                Assert.Equal(_entity.Name, _registroSelecionado.Name);
                Assert.Equal(_entity.Id, _registroSelecionado.Id);

                var _todosRegistros = await _repositorio.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() == 27);
            }

        }
    }
}
