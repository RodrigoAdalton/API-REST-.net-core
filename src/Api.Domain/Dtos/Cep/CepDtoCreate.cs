using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Cep
{
    public class CepDtoCreate
    {
        [Required(ErrorMessage = "CEP é campo obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Logradouro é campo obrigatório")]
        public string Address { get; set; }

        public string Number { get; set; }

        [Required(ErrorMessage = "Cidade é campo obrigatório")]
        public Guid CityId { get; set; }
    }
}
