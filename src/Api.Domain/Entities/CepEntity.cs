using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class CepEntity : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        public string Cep { get; set; }

        [Required]
        [MaxLength(60)]
        public string Address { get; set; }

        [MaxLength(10)]
        public string Number { get; set; }

        [Required]
        public Guid CityId { get; set; }

        public CityEntity City { get; set; }
    }
}
