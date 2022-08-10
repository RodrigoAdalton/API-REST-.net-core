using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.City.WhenRequestedDelete
{
    public class BadRequest_Return
    {
        public class Retorno_BadRequest
        {
            private CitiesController _controller;

            [Fact(DisplayName = "É possível Realizar o Deleted.")]
            public async Task E_Possivel_Invocar_a_Controller_Delete()
            {
                var serviceMock = new Mock<ICityService>();
                serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                           .ReturnsAsync(true);

                _controller = new CitiesController(serviceMock.Object);
                _controller.ModelState.AddModelError("Id", "Formato Inválido");

                var result = await _controller.Delete(Guid.NewGuid());
                Assert.True(result is BadRequestObjectResult);
            }
        }
    }
}
