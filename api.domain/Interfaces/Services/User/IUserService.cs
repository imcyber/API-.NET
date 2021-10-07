using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.domain.Entities;

namespace api.domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserEntity> Get(Guid id);
        Task<IEnumerable<UserEntity>> Getall();
        Task<UserEntity> Post(UserEntity user);
        Task<UserEntity> Put(UserEntity user);
        Task<bool> Delete(Guid id);

    }
}
