using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.City;
using Api.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.City.WhenRequestedGetAll
{
    public class GetAll_Return
    {
        private CitiesController _controller;

        [Fact(DisplayName = "É possível Realizar o GetAll.")]
        public async Task E_Possivel_Invocar_a_Controller_GetAll()
        {
            var serviceMock = new Mock<ICityService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                 new List<CityDto>
                 {
                    new CityDto
                    {
                        Id = Guid.NewGuid(),
                        Name = "São Paulo",
                    },
                    new CityDto
                    {
                        Id = Guid.NewGuid(),
                        Name = "Limeira",
                    }
                 }
            );

            _controller = new CitiesController(serviceMock.Object);
            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

        }
    }
}
