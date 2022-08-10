using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.State;
using Api.Domain.Interfaces.Services.State;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.State.WhenRequestedGet
{
    public class Get_Return
    {
        private StatesController _controller;

        [Fact(DisplayName = "É possível Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<IStateService>();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                 new StateDto
                 {
                     Id = Guid.NewGuid(),
                     Name = "São Paulo",
                     Initial = "SP"
                 }
            );

            _controller = new StatesController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

        }
    }
}
