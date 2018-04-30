using System;
using System.Data;
using System.Data.SqlClient;
using CodeChallenge.Data.Model;
using CodeChallenge.Infrastructure;

namespace CodeChallenge.Data.Sql
{
    public class LogRepository : IRepository<Log>
    {
        private readonly string _connectionString;

        public LogRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Insert(Log entity)
        {
            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Log VALUES(@message, @logLevel)";

                cmd.Parameters.AddWithValue("@message", entity.Message);
                cmd.Parameters.AddWithValue("@logLevel", entity.LogLevel);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("There are problems attemping to save the log in DB", e.InnerException);
                }
            }
        }
    }
}
