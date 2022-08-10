using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.City;
using Api.Domain.Interfaces.Services.Cep;
using Api.Domain.Interfaces.Services.City;
using Api.Service.Test.City;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class WhenExecutedGet : CepTest
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GET.")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Get(CepId)).ReturnsAsync(cepDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(CepId);
            Assert.NotNull(result);
            Assert.True(result.Id == CepId);
            Assert.Equal(CepOriginal, result.Cep);
            Assert.Equal(AddressOriginal, result.Address);

            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Get(CepOriginal)).ReturnsAsync(cepDto);
            _service = _serviceMock.Object;

            result = await _service.Get(CepOriginal);
            Assert.NotNull(result);
            Assert.True(result.Id == CepId);
            Assert.Equal(CepOriginal, result.Cep);
            Assert.Equal(AddressOriginal, result.Address);

            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CepDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(Guid.NewGuid());
            Assert.Null(_record);
        }
    }
}
