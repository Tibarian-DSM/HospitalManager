using ADOTools;
using HospitalManager.DAL.Entities;
using HospitalManager.DAL.Interfaces;
using HospitalManager.DAL.Mappers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Repositories
{
    public class ServicesRepository : IServicesRepository
    {
        private readonly Connection _connection;

        public ServicesRepository(Connection connection)
        {
            _connection = connection;
        }
        public void addNewService(string name)
        {
            Command cmd = new Command("INSERT INTO [Service]([Name]) VALUES (@Name)");
            cmd.AddParameter("Name", name);

            _connection.ExecNonQuery(cmd);
        }

        public void deleteService(int id)
        {
            Command cmd = new Command("DELETE FROM [Service] WHERE [Id] = @Id ");
            cmd.AddParameter("Id", id);

            _connection.ExecNonQuery(cmd);
        }

        public List<ServiceMod> getAllServices()
        {
            List<ServiceMod> services = new List<ServiceMod>();

            Command cmd = new Command("SELECT * FROM [Service]");

            services = _connection.ExecReader(cmd, er => er.SDbToDal());

            return services;

        }
    }
}
