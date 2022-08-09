using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.City;
using Api.Domain.Interfaces.Services.City;
using Moq;
using Xunit;

namespace Api.Service.Test.City
{
    public class WhenExecutedGetAll : CityTest
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GETAll.")]
        public async Task E_Possivel_Executar_Metodo_GetAll()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<CityDto>();
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}
