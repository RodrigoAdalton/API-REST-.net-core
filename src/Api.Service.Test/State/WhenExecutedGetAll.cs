using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.State;
using Api.Domain.Interfaces.Services.State;
using Moq;
using Xunit;

namespace Api.Service.Test.State
{
    public class WhenExecutedGetAll : StateTest
    {
        private IStateService _service;
        private Mock<IStateService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GETAll.")]
        public async Task E_Possivel_Executar_Metodo_GetAll()
        {
            _serviceMock = new Mock<IStateService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listStateDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<StateDto>();

            _serviceMock = new Mock<IStateService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);

        }
    }
}
