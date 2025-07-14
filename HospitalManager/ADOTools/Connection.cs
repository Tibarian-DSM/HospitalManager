using Microsoft.Data.SqlClient;

namespace ADOTools
{
    public sealed class Connection
    {
        private string _connectionString; 

        public Connection (string connectionString)
        {
            _connectionString = connectionString;

        }

        private SqlCommand CreateSqlCommand(SqlConnection connection, Command command)
        {
            SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = command.Request;


            foreach (KeyValuePair<string, object?> param in command.Parameters)
            {
                sqlCommand.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
            }

            return sqlCommand;
        }

        public object? ExecuteScalar(Command command)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlCommand = CreateSqlCommand(connection,command))
                {
                    connection.Open();
                    object? result = sqlCommand.ExecuteScalar();;
                    return (result is DBNull) ? null : result;
                }
            }
        }
        public List<TResult> ExecReader<TResult>(Command command, Func<SqlDataReader, TResult> map)
        {
            List<TResult> result = new List<TResult>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlCommand = CreateSqlCommand(connection,command))
                {
                    connection.Open();
                       using (SqlDataReader reader = sqlCommand.ExecuteReader())
                       {
                             while (reader.Read())
                            {
                                result.Add(map(reader));
                            }
                        }
                }
            }
            return result;
        }

        public int ExecNonQuery(Command command)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlCommand = CreateSqlCommand(connection, command))
                {
                    connection.Open();
                    return sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
