using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.City;
using Api.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.City.WhenRequestedUpdate
{
    public class Updated_Return
    {
        private CitiesController _controller;

        [Fact(DisplayName = "É possível Realizar o Updated.")]
        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<ICityService>();
            serviceMock.Setup(m => m.Put(It.IsAny<CityDtoUpdate>())).ReturnsAsync(
                new CityDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Name = "São Paulo",
                    UpdatedAt = DateTime.UtcNow
                }
            );

            _controller = new CitiesController(serviceMock.Object);

            var municipioDtoUpdate = new CityDtoUpdate
            {
                Name = "São Paulo",
                CodIBGE = 1
            };

            var result = await _controller.Put(municipioDtoUpdate);
            Assert.True(result is OkObjectResult);

        }
    }
}
