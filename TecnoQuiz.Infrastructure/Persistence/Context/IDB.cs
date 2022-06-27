using System.Data;

namespace TecnoQuiz.Infrastructure.Persistence.Context
{
    public interface IDB: IDisposable
    {
        Task<IDbConnection> GetConAsync();
    }
}
