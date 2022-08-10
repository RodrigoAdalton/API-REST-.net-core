using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.City;
using Api.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.City.WhenRequestedGetCompleteByIBGE
{
    public class NotFound_Return
    {
        private CitiesController _controller;

        [Fact(DisplayName = "É possível Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<ICityService>();

            serviceMock.Setup(m => m.GetCompleteByIBGE(It.IsAny<int>())).Returns(Task.FromResult((CityDtoComplete)null));

            _controller = new CitiesController(serviceMock.Object);
            var result = await _controller.GetCompleteByIBGE(1);
            Assert.True(result is NotFoundResult);

        }
    }
}
