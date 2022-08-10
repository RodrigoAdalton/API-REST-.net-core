using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.State;
using Api.Domain.Interfaces.Services.State;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.State.WhenRequestedGetAll
{
    public class GetAll_Return
    {
        private StatesController _controller;

        [Fact(DisplayName = "É possível Realizar o GetAll.")]
        public async Task E_Possivel_Invocar_a_Controller_GetAll()
        {
            var serviceMock = new Mock<IStateService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                 new List<StateDto>
                 {
                    new StateDto
                    {
                        Id = Guid.NewGuid(),
                        Name = "São Paulo",
                        Initial = "SP",
                    },
                    new StateDto
                    {
                        Id = Guid.NewGuid(),
                        Name = "Amazonas",
                        Initial = "AM",
                    }
                 }
            );

            _controller = new StatesController(serviceMock.Object);
            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

        }
    }
}
