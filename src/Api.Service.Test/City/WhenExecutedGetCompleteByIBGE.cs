using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.City;
using Moq;
using Xunit;

namespace Api.Service.Test.City
{
    public class WhenExecutedGetCompleteByIBGE : CityTest
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GET Complete By IBGE.")]
        public async Task E_Possivel_Executar_Metodo_Get_Complete_by_IBGE()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.GetCompleteByIBGE(CodeIBGECity)).ReturnsAsync(cityDtoComplete);
            _service = _serviceMock.Object;

            var result = await _service.GetCompleteByIBGE(CodeIBGECity);
            Assert.NotNull(result);
            Assert.True(result.Id == CityId);
            Assert.Equal(NameCity, result.Name);
            Assert.Equal(CodeIBGECity, result.CodIBGE);
            Assert.NotNull(result.State);
        }
    }
}
