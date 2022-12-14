using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.State;
using Api.Domain.Interfaces.Services.State;
using Moq;
using Xunit;

namespace Api.Service.Test.State
{
    public class WhenExecutedGet : StateTest
    {
        private IStateService _service;
        private Mock<IStateService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GET.")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IStateService>();
            _serviceMock.Setup(m => m.Get(StateId)).ReturnsAsync(stateDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(StateId);
            Assert.NotNull(result);
            Assert.True(result.Id == StateId);
            Assert.Equal(Name, result.Name);

            _serviceMock = new Mock<IStateService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((StateDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(StateId);
            Assert.Null(_record);
        }
    }
}
