using System;
using Api.Domain.Dtos.City;

namespace Api.Domain.Dtos.Cep
{
    public class CepDto
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public Guid CityId { get; set; }
        public CityDtoComplete City { get; set; }
    }
}
