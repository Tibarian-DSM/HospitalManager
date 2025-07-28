using ADOTools;
using HospitalManager.DAL.Entities;
using HospitalManager.DAL.Interfaces;
using HospitalManager.DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Repositories
{
    public class AppointementRepository : IAppointementRepository
    {
        private readonly Connection _connection;
        

        public AppointementRepository(Connection connection)
        {
            _connection = connection;
        }
        public void createAppointement(Appointement appointement)
        {
            Command cmd = new Command("INSERT INTO [Appointement]([Appointement_Date] , [Subject] , [Medic_Id], [Patient_Id]) " +
                                         "VALUES (@Appointement_Date , @Subject , @Medic_Id , @Patient_Id )");

            cmd.AddParameter("Appointement_Date", appointement.Appointement_Date);
            cmd.AddParameter("Subject", appointement.Subject);
            cmd.AddParameter("Medic_Id",appointement.Medic_Id);
            cmd.AddParameter("Patient_Id", appointement.Patient_Id);

            _connection.ExecNonQuery(cmd);
        }

        public GotAppointement GetAppointementById(int id)
        {

            Command cmd = new Command("SELECT A.[Id],Appointement_Date,[Subject], P.[FirstName] PFirstName,P.[LastName]PLastName, M.[FirstName]MFirstName, M.[LastName]MLastName" + 
                                                                       " FROM [Appointement]A " +  
                                                                       "JOIN [User]M ON  A.[Medic_Id] =  M.Id " +
                                                                       "JOIN [User]P ON A.Patient_Id = P.[Id]" +
                                                                       "WHERE A.Id = @Id");
            cmd.AddParameter("Id", id);

            return _connection.ExecReader(cmd, er => er.ApDbToDal()).FirstOrDefault();
    
        }

        public List<GotAppointement> GetAppointementsByPatientId(int id)
        {

            Command cmd = new Command("SELECT A.[Id],Appointement_Date,[Subject], P.[FirstName] PFirstName,P.[LastName]PLastName, M.[FirstName]MFirstName, M.[LastName]MLastName" +
                                                                       " FROM [Appointement]A " +
                                                                       "JOIN [User]M ON  A.[Medic_Id] =  M.Id " +
                                                                       "JOIN [User]P ON A.Patient_Id = P.[Id]" +
                                                                       "WHERE P.Id = @Id");
            cmd.AddParameter("Id", id);

            return _connection.ExecReader(cmd, er => er.ApDbToDal());
        }

        public List<GotAppointement> GetAppointementsByMedicId(int id)
        {

            Command cmd = new Command("SELECT A.[Id],Appointement_Date,[Subject], P.[FirstName] PFirstName,P.[LastName]PLastName, M.[FirstName]MFirstName, M.[LastName]MLastName" +
                                                                       " FROM [Appointement]A " +
                                                                       "JOIN [User]M ON  A.[Medic_Id] =  M.Id " +
                                                                       "JOIN [User]P ON A.Patient_Id = P.[Id]" +
                                                                       "WHERE M.Id = @Id");
            cmd.AddParameter("Id", id);

            return _connection.ExecReader(cmd, er => er.ApDbToDal());
        }
    }
}
