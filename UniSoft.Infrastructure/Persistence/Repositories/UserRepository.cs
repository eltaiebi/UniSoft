using Dapper;
using System.Data;
using UniSoft.Domain.Entities;
using UniSoft.Domain.Interfaces;

namespace UniSoft.Infrastructure.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDbConnection connection) : base(connection) { }

        public async Task<User> GetByUsernameAsync(string username)
        {
            var sql = "SELECT * FROM Users WHERE Username = @Username";
            return await _connection.QueryFirstOrDefaultAsync<User>(sql, new { Username = username });
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var sql = "SELECT * FROM Users WHERE Email = @Email";
            return await _connection.QueryFirstOrDefaultAsync<User>(sql, new { Email = email });
        }
    }
}
