using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.domain.Dtos.User;
using api.domain.Entities;

namespace api.domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDto> Get(Guid id);
        Task<IEnumerable<UserDto>> Getall();
        Task<UserDtoCreateResult> Post(UserDtoCreate user);
        Task<UserDtoUpdateResult> Put(UserDtoUpdate user);
        Task<bool> Delete(Guid id);

    }
}
