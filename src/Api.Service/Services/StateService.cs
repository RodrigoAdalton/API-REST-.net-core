using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.State;
using Api.Domain.Interfaces.Services.State;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class StateService : IStateService
    {
        private IStateRepository _repository;
        private readonly IMapper _mapper;

        public StateService(IStateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StateDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<StateDto>(entity);
        }

        public async Task<IEnumerable<StateDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<StateDto>>(listEntity);
        }
    }
}
