using System;

namespace Api.Domain.Dtos.Cep
{
    public class CepDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public Guid CityId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
