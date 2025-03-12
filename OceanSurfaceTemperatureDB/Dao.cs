using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OceanSurfaceTemperatureDB
{
    class Dao : IDisposable
    {
        private readonly SqlConnection _connection;

        public Dao()
        {
            string connectionString = @"Data Source=LAPTOP-V08ARU8E;Initial Catalog=OceanDB;Integrated Security=True;";
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public SqlCommand CreateCommand(string sql)
        {
            return new SqlCommand(sql, _connection);
        }

        public int Execute(string sql)
        {
            using (SqlCommand cmd = CreateCommand(sql))
            {
                return cmd.ExecuteNonQuery();
            }
        }
        public SqlDataReader ExecuteReader(string sql)
        {
            SqlCommand cmd = CreateCommand(sql);
            return cmd.ExecuteReader();
        }
        public object ExecuteScalar(string sql)
        {
            using (SqlCommand command = new SqlCommand(sql, _connection))
            {
                return command.ExecuteScalar();
            }
        }

        public async Task<SqlDataReader> ReadAsync(string sql)
        {
            SqlCommand cmd = CreateCommand(sql);
            return await cmd.ExecuteReaderAsync();
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
