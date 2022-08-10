using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Dtos.City;

namespace Api.Domain.Entities
{
    public class CityEntity : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        public int CodIBGE { get; set; }

        [Required]
        public Guid StateId { get; set; }
        public StateEntity State { get; set; }

        public IEnumerable<CepEntity> Ceps { get; set; }
    }
}
