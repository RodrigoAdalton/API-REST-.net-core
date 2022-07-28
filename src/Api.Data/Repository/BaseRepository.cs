using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BaseRepository<R> : IRepository<R> where R : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<R> _dataset;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<R>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));

                if (result == null)
                {
                    return false;
                }

                _dataset.Remove(result);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<R> InsertAsync(R request)
        {
            try
            {
                if (request.Id == Guid.Empty)
                {
                    request.Id = Guid.NewGuid();
                }

                request.CreatedAt = DateTime.UtcNow;
                _dataset.Add(request);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return request;
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<R> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<R>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<R> UpdateAsync(R request)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(request.Id));

                if (result == null)
                {
                    return null;
                }

                request.UpdatedAt = DateTime.UtcNow;
                request.CreatedAt = result.CreatedAt;

                _context.Entry(result).CurrentValues.SetValues(request);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return request;
        }
    }
}
