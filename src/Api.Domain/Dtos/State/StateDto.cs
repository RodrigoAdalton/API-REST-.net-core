using System;

namespace Api.Domain.Dtos.State
{
    public class StateDto
    {
        public Guid Id { get; set; }
        public string Initial { get; set; }
        public string Name { get; set; }
    }
}
