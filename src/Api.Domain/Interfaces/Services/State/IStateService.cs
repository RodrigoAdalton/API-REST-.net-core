using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.State;

namespace Api.Domain.Interfaces.Services.State
{
    public interface IStateService
    {
        Task<StateDto> Get(Guid id);
        Task<IEnumerable<StateDto>> GetAll();
    }
}
