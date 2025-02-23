using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurJourney.Application.Common.Interface;

namespace OurJourney.Persistence.DataBase
{
    internal class OutJourneyDataBase : IDataBase
    {
        private SqlConnection _connection;
        private readonly string _connectionString;

        public OutJourneyDataBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            if (_connection == null || string.IsNullOrWhiteSpace(_connection.ConnectionString))
            {
                _connection = new SqlConnection(_connectionString);
            }
            return _connection;
        }
    }
}
