using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.City
{
    public class CityDtoUpdate
    {
        [Required(ErrorMessage = "Id é campo Obrigatorio")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome de Cidade é campo Obrigatorio")]
        [StringLength(60, ErrorMessage = "Nome de Cidade deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Código do IBGE Inválido")]
        public int CodIBGE { get; set; }

        [Required(ErrorMessage = "Código de UF é campo Obrigatorio")]
        public Guid StateId { get; set; }
    }
}
