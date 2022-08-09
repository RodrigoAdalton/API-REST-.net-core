using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.City;
using Moq;
using Xunit;

namespace Api.Service.Test.City
{
    public class WhenExecutedDelete : CityTest
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;
        [Fact(DisplayName = "É possível executar método Delete.")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Delete(CityId))
                        .ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(CityId);
            Assert.True(deletado);

            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                        .ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);
        }
    }
}
