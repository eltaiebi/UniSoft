using UniSoft.Application.DTOs;
using UniSoft.Domain.Entities;

namespace UniSoft.Application.Interfaces
{
    public interface IUserService : IGenericService<User, UserDto>
    {
        Task<UserDto> GetByUsernameAsync(string username);
        Task<UserDto> GetByEmailAsync(string email);
    }
}