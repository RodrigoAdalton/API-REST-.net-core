using System;

namespace Api.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        private DateTime? _createdAt { get; set; }

        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = (value == null) ? DateTime.UtcNow : value; }
        }

        public DateTime? UpdatedAt { get; set; }
    }
}
