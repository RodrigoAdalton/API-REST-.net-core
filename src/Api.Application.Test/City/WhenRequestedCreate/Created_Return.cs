using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.City;
using Api.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.City.WhenRequestedCreate
{
    public class Created_Return
    {
        private CitiesController _controller;

        [Fact(DisplayName = "É possível Realizar o Created.")]
        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<ICityService>();
            serviceMock.Setup(m => m.Post(It.IsAny<CityDtoCreate>())).ReturnsAsync(
                new CityDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Name = "São Paulo",
                    CreatedAt = DateTime.UtcNow
                }
            );

            _controller = new CitiesController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var municipioDtoCreate = new CityDtoCreate
            {
                Name = "São Paulo",
                CodIBGE = 1
            };

            var result = await _controller.Post(municipioDtoCreate);
            Assert.True(result is CreatedResult);

        }
    }
}
