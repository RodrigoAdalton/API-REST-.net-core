using System.Linq;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class StateImplementation : BaseRepository<StateEntity>, IStateRepository
    {
        private DbSet<StateEntity> _dataset;

        public StateImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<StateEntity>();
        }
    }
}
