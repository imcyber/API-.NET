using System.Threading.Tasks;
using api.domain.Dtos;

namespace api.domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDto user);
    }
}
