using CustomExceptions;
using System.Data.SqlClient;

// namespace DataAccess
// {
    public class ConnectionFactory
    {

        private static ConnectionFactory? _instance;
        private readonly string _connectionFactory;

        private ConnectionFactory(string connectionString)
        {
            _connectionFactory = connectionString;
        }

        public static ConnectionFactory GetInstance(string connectionString)
        {
            if(_instance == null)
            {
                _instance = new ConnectionFactory(connectionString);
            }
            return _instance;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionFactory);
        }

    }
// }
