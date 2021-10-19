using System.Threading.Tasks;
using api.domain.Entities;
using api.domain.Interfaces;

namespace api.domain.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);
    }
}
