using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.WhenRequestedUpdate
{
    public class BadRequest_Return
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possível Realizar o Updated.")]
        public async Task E_Possivel_Invocar_a_Controller_Update()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Put(It.IsAny<CepDtoUpdate>())).ReturnsAsync(
                new CepDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Address = "Teste de Rua",
                    UpdatedAt = DateTime.UtcNow
                }
            );

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Nome", "É um Campo Obrigatório");

            var cepDtoUpdate = new CepDtoUpdate
            {
                Address = "Teste de Rua",
                Cep = "10333444"
            };

            var result = await _controller.Put(cepDtoUpdate);
            Assert.True(result is BadRequestObjectResult);

        }
    }
}
