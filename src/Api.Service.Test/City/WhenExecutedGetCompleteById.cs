using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.City;
using Moq;
using Xunit;


namespace Api.Service.Test.City
{
    public class WhenExecutedGetCompleteById : CityTest
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GET Complete By Id.")]
        public async Task E_Possivel_Executar_Metodo_Get_Complete_by_Id()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.GetCompleteById(CityId)).ReturnsAsync(cityDtoComplete);
            _service = _serviceMock.Object;

            var result = await _service.GetCompleteById(CityId);
            Assert.NotNull(result);
            Assert.True(result.Id == CityId);
            Assert.Equal(NameCity, result.Name);
            Assert.Equal(CodeIBGECity, result.CodIBGE);
            Assert.NotNull(result.State);
        }
    }
}
