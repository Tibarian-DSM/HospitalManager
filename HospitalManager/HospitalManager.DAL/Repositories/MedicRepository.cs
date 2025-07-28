using ADOTools;
using HospitalManager.DAL.Entities;
using HospitalManager.DAL.Interfaces;
using HospitalManager.DAL.Mappers.Medic;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Repositories
{
    public class MedicRepository : IMedicRepository
    {
        private readonly Connection _connection;

        public MedicRepository(Connection connection)
        {
            _connection = connection;
        }
        public void addNewMedic(Medic medic)
        {
            int userId; 

            Command ucmd = new Command("INSERT INTO [dbo].[User]([FirstName], [LastName], [Email], [Password] ,[Role_Id])" +
                                              "OUTPUT inserted.Id" +
                                             " VALUES (@FirstName, @LastName, @Email, @Password, @Role_id)");
            ucmd.AddParameter("FirstName", medic.FirstName);
            ucmd.AddParameter("LastName", medic.LastName);
            ucmd.AddParameter("Email", medic.Email);
            ucmd.AddParameter("Password", medic.Password);
            ucmd.AddParameter("Role_id", 2);

           userId = (int)_connection.ExecScalar(ucmd);

            Command ecmd = new Command("INSERT INTO [dbo].[Employee]([User_Id], [Contract], [HireDate], [ContractEnd]) " +
                                         "VALUES (@User_Id , @Contract , @HireDate , @ContractEnd )");
            ecmd.AddParameter("User_Id", userId);
            ecmd.AddParameter("Contract", medic.Contract);
            ecmd.AddParameter("HireDate", medic.HireDate);
            ecmd.AddParameter("ContractEnd", medic.ContractEnd);

            _connection.ExecNonQuery(ecmd);

            Command scmd = new Command("INSERT INTO [dbo].[Employee_Service]([Employee_Id] , [Service_Id]) " +
                                        "VALUES ( @Employee_Id , @Service_Id )");
            scmd.AddParameter("Employee_Id",userId);
            scmd.AddParameter("Service_Id",medic.Service_Id);

            _connection.ExecNonQuery(scmd);

            Command mcmd = new Command("INSERT INTO [dbo].[Medic]([User_Id], [Inami], [Specialty], [Is_Subsized]) " +
                                        " VALUES (@User_Id, @Inami , @Specialty , @Is_subsized )");
            mcmd.AddParameter("User_Id", userId);
            mcmd.AddParameter("Inami", medic.Inami);
            mcmd.AddParameter("Specialty", medic.Speciality);
            mcmd.AddParameter("Is_subsized", medic.Is_Subsized);

            _connection.ExecNonQuery(mcmd);
        }

        public GotMedic GetMedicDetails(int id)
        {
            Command cmd = new Command("SELECT U.[Id] , [FirstName] ,[LastName] , [Email]," +
                                        "R.[Name] RName , " +
                                        "S.[Name] SName," +
                                        "[Contract] ,[HireDate],[ContractEnd], " +
                                        "[Inami] , [Specialty],[Is_Subsized] " +
                                        "FROM [User]U " +
                                        "JOIN [Role]R ON R.[Id] = U.[Role_Id] " +
                                        "JOIN [Employee]E ON  E.[User_Id] =  U.[Id] " +
                                        "JOIN [Employee_Service]ES ON ES.Employee_Id = E.[User_Id] " +
                                        "JOIN [Service]S ON S.[Id] = Es.[Service_Id] " +
                                        "JOIN [Medic]M ON M.[User_Id] = E.[User_Id] " +
                                        "WHERE U.[Id] = @Id");
            cmd.AddParameter("Id", id);

            return _connection.ExecReader(cmd, er => er.MDbToDal()).SingleOrDefault();
        }

        public List<MedicLow> GetMedicsByService(int serviceId)
        {
            List<MedicLow > list = new List<MedicLow>();
            Command cmd = new Command("SELECT E.[User_Id] , [FirstName], [LastName] , [Specialty] , [Is_Subsized] " +
                                       "FROM [User]U " +
                                       "JOIN [Employee]E ON  E.[User_Id] =  U.[Id] " +
                                       "JOIN [Employee_Service]ES ON ES.Employee_Id = E.[User_Id] " +
                                       "JOIN [Service]S ON S.[Id] = Es.[Service_Id] " +
                                        "JOIN [Medic]M ON M.[User_Id] = E.[User_Id] " +
                                        " WHERE Es.[Service_Id] = @Service_Id");

            cmd.AddParameter("Service_Id", serviceId);

            list= _connection.ExecReader(cmd,er => er.MLDbToDal());

            return list;

        }
    }
}
