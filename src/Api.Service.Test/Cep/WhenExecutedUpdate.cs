using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Cep;
using Api.Service.Test.City;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class WhenExecutedUpdate : CepTest
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Update.")]
        public async Task E_Possivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Put(cepDtoUpdate)).ReturnsAsync(cepDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(cepDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(CepChanged, resultUpdate.Cep);
            Assert.Equal(AddressChanged, resultUpdate.Address);
            Assert.Equal(NumberChanged, resultUpdate.Number);

        }
    }
}
