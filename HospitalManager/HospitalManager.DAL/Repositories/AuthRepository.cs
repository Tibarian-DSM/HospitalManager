using ADOTools;
using HospitalManager.DAL.Entities;
using HospitalManager.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
