using ADOTools;
using HospitalManager.DAL.Entities;
using HospitalManager.DAL.Interfaces;
using HospitalManager.DAL.Mappers.AuthMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Connection _connection;

        public UserRepository(Connection connection)
        {
            _connection = connection;
        }
        public GotUser getUserById(int id)
        {
            Command cmd = new Command("SELECT U.[Id] ,[Firstname], [LastName] , [Email] , [Name] " +
                               "FROM [User] U " +
                               "JOIN [Role] R " +
                               "ON U.Role_Id = R.Id " +
                               "WHERE U.Id = @Id");

            cmd.AddParameter("id", id);

           return _connection.ExecReader(cmd, er => er.DbToDal()).SingleOrDefault();

        }

        public List<GotUser> getUsersByRole(string role)
        {
            Command cmd = new Command("SELECT U.[Id] ,[Firstname], [LastName] , [Email] , [Name] " +
                   "FROM [User] U " +
                   "JOIN [Role] R " +
                   "ON U.Role_Id = R.Id " +
                   "WHERE R.Name = @Name");

            cmd.AddParameter("Name", role);

            return _connection.ExecReader(cmd, er=> er.DbToDal());
        }
    }
}
