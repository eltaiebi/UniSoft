using static UniSoft.Application.Interfaces.IService;
using UniSoft.Application.DTOs;
using UniSoft.Domain.Entities;

namespace UniSoft.Application.Interfaces
{
    public interface IUserService : IService<User, UserDto>
    {
        Task<UserDto> GetByUsernameAsync(string username);
        Task<UserDto> GetByEmailAsync(string email);
    }
}
