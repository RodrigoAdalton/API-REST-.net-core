using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IRepository<R> where R : BaseEntity
    {
        Task<R> InsertAsync(R request);

        Task<R> UpdateAsync(R request);

        Task<bool> DeleteAsync(Guid id);

        Task<R> SelectAsync(Guid id);

        Task<IEnumerable<R>> SelectAsync();

        Task<bool> ExistAsync(Guid id);
    }
}
