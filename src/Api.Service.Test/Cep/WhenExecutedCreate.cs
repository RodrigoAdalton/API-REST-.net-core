using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Cep;
using Api.Domain.Interfaces.Services.City;
using Api.Service.Test.City;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class WhenExecutedCreate : CepTest
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Create.")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Post(cepDtoCreate)).ReturnsAsync(cepDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(cepDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(CepOriginal, result.Cep);
            Assert.Equal(AddressOriginal, result.Address);
            Assert.Equal(NumberOriginal, result.Number);

        }
    }
}
