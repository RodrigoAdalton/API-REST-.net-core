using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.State;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.State
{
    public class WhenRequestedState : BaseIntegration
    {
        [Fact]
        public async Task E_Possivel_Realizar_Crud_Usuario()
        {
            await AdicionarToken();

            //Get All
            response = await client.GetAsync($"{hostApi}states");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<StateDto>>(jsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count() == 27);
            Assert.True(listaFromJson.Where(r => r.Initial == "SP").Count() == 1);

            var id = listaFromJson.Where(r => r.Initial == "SP").FirstOrDefault().Id;
            response = await client.GetAsync($"{hostApi}states/{id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<StateDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal("São Paulo", registroSelecionado.Name);
            Assert.Equal("SP", registroSelecionado.Initial);
        }
    }
}
