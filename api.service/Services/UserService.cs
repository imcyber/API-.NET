using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.domain.Dtos.User;
using api.domain.Entities;
using api.domain.Interfaces;
using api.domain.Interfaces.Services.User;
using api.domain.Models;
using AutoMapper;

namespace api.service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UserDto>(entity) ?? new UserDto();
        }

        public async Task<IEnumerable<UserDto>> Getall()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserDto>>(listEntity);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            var model = _mapper.Map<UserModels>(user);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate user)
        {
            var model = _mapper.Map<UserModels>(user);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<UserDtoUpdateResult>(result);
        }
    }
}
