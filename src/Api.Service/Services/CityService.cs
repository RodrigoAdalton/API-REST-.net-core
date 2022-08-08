using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.City;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.City;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class CityService : ICityService
    {
        private ICityRepository _repository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CityDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CityDto>(entity);
        }

        public async Task<CityDtoComplete> GetCompleteById(Guid id)
        {
            var entity = await _repository.GetCompleteById(id);
            return _mapper.Map<CityDtoComplete>(entity);
        }

        public async Task<CityDtoComplete> GetCompleteByIBGE(int codIBGE)
        {
            var entity = await _repository.GetCompleteByIBGE(codIBGE);
            return _mapper.Map<CityDtoComplete>(entity);
        }

        public async Task<IEnumerable<CityDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<CityDto>>(listEntity);
        }

        public async Task<CityDtoCreateResult> Post(CityDtoCreate city)
        {
            var model = _mapper.Map<CityModel>(city);
            var entity = _mapper.Map<CityEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<CityDtoCreateResult>(result);
        }

        public async Task<CityDtoUpdateResult> Put(CityDtoUpdate city)
        {
            var model = _mapper.Map<CityModel>(city);
            var entity = _mapper.Map<CityEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<CityDtoUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
