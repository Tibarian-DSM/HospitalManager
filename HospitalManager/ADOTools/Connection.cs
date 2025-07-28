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

        // Méthode qui transforme un objet Command (requête + paramètres) en SqlCommand exécutable
        private SqlCommand CreateSqlCommand(SqlConnection connection, Command command)
        {
            // Crée une commande SQL attachée à la connexion
            SqlCommand sqlCommand = connection.CreateCommand();
            // Assigne le texte de la commande
            sqlCommand.CommandText = command.Request;

            // Ajoute tous les paramètres 
            foreach (KeyValuePair<string, object?> param in command.Parameters)
            {
                sqlCommand.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
            }

            return sqlCommand;
        }
        #region ExecuteScalar qui permet de retourner un résultat unique
        public object? ExecScalar(Command command)
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
        #endregion

        #region ExecuteReader permettant de récupérer plusieur ligne ou une seul ligne si on rajoute FirstOrDefault
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
        #endregion

        #region ExecuteNonQuery permettant l'execution d'une requete ne demandant pas de résultat
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
        #endregion
    }
}
