using System;

namespace Api.Domain.Dtos.City
{
    public class CityDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CodIBGE { get; set; }
        public Guid StateId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
