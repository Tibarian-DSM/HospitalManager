using ADOTools;
using HospitalManager.DAL.Entities;
using HospitalManager.DAL.Interfaces;
using HospitalManager.DAL.Mappers.AuthMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Repositories
{
 
    public class AuthRepository : IAuthRepository
    {   
        private readonly Connection _connection;

        public AuthRepository(Connection connection)
        {
            _connection = connection;
        }
        public void RegisterUser(User user)
        {
            Command cmd = new Command("INSERT INTO[dbo].[User]([FirstName], [LastName], [Email], [Password])" +
                                              "OUTPUT inserted.Id" +
                                             " VALUES (@FirstName, @LastName, @Email, @Password)");
            cmd.AddParameter("FirstName",user.FirstName);
            cmd.AddParameter("LastName", user.LastName);
            cmd.AddParameter("Email", user.Email);
            cmd.AddParameter("Password", user.Password);

            _connection.ExecNonQuery(cmd);
        }

        public string GetPassword(string email)
        {
            string? record;
            Command cmd = new Command("SELECT [Password] FROM [User] " +
                                        " WHERE [Email] = @Email ");

            cmd.AddParameter("Email", email);

            if (cmd != null && _connection != null)
            {
                record = _connection.ExecScalar(cmd)?.ToString();

                if (record == null)
                {
                    throw new Exception("null value");
                }
                else
                {
                    return record;
                }
            }
            else
            {
                throw new Exception("command or connection null");
            }
        }

        public GotUser GetUserByEmail(string email)
        {
            Command cmd = new Command("SELECT U.[Id] ,[Firstname], [LastName] , [Email] , [Name] " +
                            "FROM [User] U " +
                            "JOIN [Role] R " +
                            "ON U.Role_Id = R.Id " +
                            "WHERE [Email] = @Email");

            cmd.AddParameter("Email", email);

            return _connection.ExecReader(cmd, er => er.DbToDal()).FirstOrDefault();
        }
    }
}
