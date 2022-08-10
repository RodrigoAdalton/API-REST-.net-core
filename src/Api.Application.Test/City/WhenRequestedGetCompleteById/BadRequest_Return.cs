using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.City;
using Api.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;


namespace Api.Application.Test.City.WhenRequestedGetCompleteById
{
    public class BadRequest_Return
    {
        private CitiesController _controller;

        [Fact(DisplayName = "É possível Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<ICityService>();

            serviceMock.Setup(m => m.GetCompleteById(It.IsAny<Guid>())).ReturnsAsync(
                 new CityDtoComplete
                 {
                     Id = Guid.NewGuid(),
                     Name = "São Paulo",
                 }
            );

            _controller = new CitiesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.GetCompleteById(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);

        }
    }
}
