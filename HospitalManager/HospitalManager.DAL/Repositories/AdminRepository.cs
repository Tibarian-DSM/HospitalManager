using ADOTools;
using HospitalManager.DAL.Entities;
using HospitalManager.DAL.Interfaces;
using HospitalManager.DAL.Mappers.AuthMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly Connection _connection;

        public AdminRepository(Connection connection)
        {
            _connection = connection;
        }

        public List<GotUser> GetAll()
        {
            Command cmd = new Command("SELECT U.[Id] ,[Firstname], [LastName] , [Email] , [Name] " +
                               "FROM [User] U " +
                               "JOIN [Role] R " +
                               "ON U.Role_Id = R.Id ");

            List<GotUser> users = _connection.ExecReader(cmd, er => er.DbToDal());

            return users;

        }
    }
}
