using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.City;
using Moq;
using Xunit;

namespace Api.Service.Test.City
{
    public class WhenExecutedUpdate : CityTest
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Update.")]
        public async Task E_Possivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Put(cityDtoUpdate)).ReturnsAsync(cityDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(cityDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NameCityChanged, resultUpdate.Name);
            Assert.Equal(CodeIBGECityChanged, resultUpdate.CodIBGE);
            Assert.Equal(StateId, resultUpdate.StateId);

        }
    }
}
