using TecnoQuiz.Infrastructure.Persistence.Context;

namespace TecnoQuiz.API.Configuration
{
    public class MSSQLConfiguration : IDBConfiguration
    {
        private readonly IConfiguration _configuration;

        public MSSQLConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ConnectionString => _configuration.GetConnectionString("TecnoQuiz");
    }
}
