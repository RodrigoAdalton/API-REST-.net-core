using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.City;
using Moq;
using Xunit;

namespace Api.Service.Test.City
{
    public class WhenExecutedCreate : CityTest
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Create.")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Post(cityDtoCreate)).ReturnsAsync(cityDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(cityDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NameCity, result.Name);
            Assert.Equal(CodeIBGECity, result.CodIBGE);
            Assert.Equal(StateId, result.StateId);
        }
    }
}
