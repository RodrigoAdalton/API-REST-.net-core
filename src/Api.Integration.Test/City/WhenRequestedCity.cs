using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Dtos.City;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.City
{
    public class WhenRequestedCity : BaseIntegration
    {
        [Fact]
        public async Task E_Possivel_Realizar_Crud_City()
        {
            await AdicionarToken();

            var cityDto = new CityDtoCreate()
            {
                Name = "São Paulo",
                CodIBGE = 3550308,
                StateId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
            };


            //Post
            var response = await PostJsonAsync(cityDto, $"{hostApi}cities", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<CityDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("São Paulo", registroPost.Name);
            Assert.Equal(3550308, registroPost.CodIBGE);
            Assert.True(registroPost.Id != default(Guid));

            //Get All
            response = await client.GetAsync($"{hostApi}cities");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<CityDto>>(jsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count() > 0);
            Assert.True(listaFromJson.Where(r => r.Id == registroPost.Id).Count() == 1);

            var updateCityDto = new CityDtoUpdate()
            {
                Id = registroPost.Id,
                Name = "Limeira",
                CodIBGE = 3526902,
                StateId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
            };

            //PUT
            var stringContent = new StringContent(JsonConvert.SerializeObject(updateCityDto),
                                    Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}Cities", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<CityDtoUpdateResult>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Limeira", registroAtualizado.Name);
            Assert.Equal(3526902, registroAtualizado.CodIBGE);

            //GET Id
            response = await client.GetAsync($"{hostApi}Cities/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<CityDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.Name, registroAtualizado.Name);
            Assert.Equal(registroSelecionado.CodIBGE, registroAtualizado.CodIBGE);

            //GET Complete/Id
            response = await client.GetAsync($"{hostApi}Cities/Complete/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionadoCompleto = JsonConvert.DeserializeObject<CityDtoComplete>(jsonResult);
            Assert.NotNull(registroSelecionadoCompleto);
            Assert.Equal(registroSelecionadoCompleto.Name, registroAtualizado.Name);
            Assert.Equal(registroSelecionadoCompleto.CodIBGE, registroAtualizado.CodIBGE);
            Assert.NotNull(registroSelecionadoCompleto.State);
            Assert.Equal("São Paulo", registroSelecionadoCompleto.State.Name);
            Assert.Equal("SP", registroSelecionadoCompleto.State.Initial);

            //GET byIBGE/CodIBGE
            response = await client.GetAsync($"{hostApi}Cities/byIBGE/{registroAtualizado.CodIBGE}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionadoIBGECompleto = JsonConvert.DeserializeObject<CityDtoComplete>(jsonResult);
            Assert.NotNull(registroSelecionadoIBGECompleto);
            Assert.Equal(registroSelecionadoIBGECompleto.Name, registroAtualizado.Name);
            Assert.Equal(registroSelecionadoIBGECompleto.CodIBGE, registroAtualizado.CodIBGE);
            Assert.NotNull(registroSelecionadoIBGECompleto.State);
            Assert.Equal("São Paulo", registroSelecionadoIBGECompleto.State.Name);
            Assert.Equal("SP", registroSelecionadoIBGECompleto.State.Initial);

            //DELETE
            response = await client.DeleteAsync($"{hostApi}Cities/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //GET ID depois do DELETE
            response = await client.GetAsync($"{hostApi}Cities/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }
    }
}
