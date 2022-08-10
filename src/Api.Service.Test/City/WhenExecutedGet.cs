using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.City;
using Api.Domain.Interfaces.Services.City;
using Moq;
using Xunit;

namespace Api.Service.Test.City
{
    public class WhenExecutedGet : CityTest
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GET.")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Get(CityId)).ReturnsAsync(cityDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(CityId);
            Assert.NotNull(result);
            Assert.True(result.Id == CityId);
            Assert.Equal(NameCity, result.Name);
            Assert.Equal(CodeIBGECity, result.CodIBGE);

            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CityDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(Guid.NewGuid());
            Assert.Null(_record);
        }
    }
}
