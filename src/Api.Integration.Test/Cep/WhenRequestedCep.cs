using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.City;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Cep
{
    public class WhenRequestedCep : BaseIntegration
    {
        [Fact]
        public async Task E_Possivel_Realizar_Crud_CEP()
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

            var cepDto = new CepDtoCreate()
            {
                Cep = "13480180",
                Address = "Rua Boa Morte",
                Number = "até nº 200",
                CityId = registroPost.Id
            };

            //Post
            response = await PostJsonAsync(cepDto, $"{hostApi}ceps", client);
            postResult = await response.Content.ReadAsStringAsync();
            var registroCepPost = JsonConvert.DeserializeObject<CepDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(cepDto.Cep, registroCepPost.Cep);
            Assert.Equal(cepDto.Address, registroCepPost.Address);
            Assert.Equal(cepDto.Number, registroCepPost.Number);
            Assert.True(registroCepPost.Id != default(Guid));

            var cepCityDto = new CepDtoUpdate()
            {
                Id = registroCepPost.Id,
                Cep = "13480180",
                Address = "Rua da Liberdade",
                Number = "até nº 200",
                CityId = registroPost.Id
            };

            //PUT
            var stringContent = new StringContent(JsonConvert.SerializeObject(cepCityDto),
                                    Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}ceps", stringContent);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<CepDtoUpdateResult>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(cepCityDto.Address, registroAtualizado.Address);

            //GET Id
            response = await client.GetAsync($"{hostApi}ceps/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<CepDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(cepCityDto.Address, registroSelecionado.Address);

            //GET Cep
            response = await client.GetAsync($"{hostApi}ceps/byCep/{registroAtualizado.Cep}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            registroSelecionado = JsonConvert.DeserializeObject<CepDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(cepCityDto.Address, registroSelecionado.Address);

            //DELETE
            response = await client.DeleteAsync($"{hostApi}ceps/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //GET ID depois do DELETE
            response = await client.GetAsync($"{hostApi}ceps/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }
    }
}
