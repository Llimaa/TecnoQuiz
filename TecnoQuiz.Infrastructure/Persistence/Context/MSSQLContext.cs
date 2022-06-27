using System.Data;
using System.Data.SqlClient; 

namespace TecnoQuiz.Infrastructure.Persistence.Context
{
    public class MSSQLContext : IDB
    {
        private SqlConnection _connection;
        private readonly string _con;

        public MSSQLContext(IDBConfiguration config)
        {
            _con = config.ConnectionString;
        }
        public void Dispose()
        {
            if (_connection != null)
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();

                _connection.Dispose();
            }
        }

        public async Task<IDbConnection> GetConAsync()
        {
            return await Task.Run(() => { return _connection = new SqlConnection(_con); });
        }
    }
}
