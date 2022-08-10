using System;
using System.Collections.Generic;
using Api.Domain.Dtos.State;

namespace Api.Service.Test.State
{
    public class StateTest
    {
        public static string Name { get; set; }
        public static string Initial { get; set; }
        public static Guid StateId { get; set; }

        public List<StateDto> listStateDto = new List<StateDto>();
        public StateDto stateDto;

        public StateTest()
        {
            StateId = Guid.NewGuid();
            Initial = Faker.Address.UsState().Substring(1, 3);
            Name = Faker.Address.UsState();

            for (int i = 0; i < 10; i++)
            {
                var dto = new StateDto()
                {
                    Id = Guid.NewGuid(),
                    Initial = Faker.Address.UsState().Substring(1, 3),
                    Name = Faker.Address.UsState()
                };
                listStateDto.Add(dto);
            };

            stateDto = new StateDto
            {
                Id = StateId,
                Initial = Initial,
                Name = Name
            };
        }
    }
}
