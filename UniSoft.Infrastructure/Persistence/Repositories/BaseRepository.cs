using System.Data;
using UniSoft.Domain.Interfaces;

namespace UniSoft.Infrastructure.Persistence.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        protected readonly IDbConnection _connection;
        public BaseRepository(IDbConnection connection)
        {
            _connection = connection;
        }
    }

}
