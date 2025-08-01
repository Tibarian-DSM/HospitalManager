﻿using ADOTools;
using HospitalManager.DAL.Entities;
using HospitalManager.DAL.Interfaces;
using HospitalManager.DAL.Mappers.AuthMapper;
using HospitalManager.DAL.Mappers.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly Connection _connection;

        public PatientRepository(Connection connection)
        {
            _connection = connection;
        }

        public void AddNewPatientFile(PatientFile file)
        {
            Command cmd = new Command("INSERT INTO [dbo].[Patient]([User_Id], [PhoneNumber], [Adress], [BirthDate],[MedicalInfo]) " +
                                             " VALUES (@User_Id, @PhoneNumber, @Adress, @BirthDate , @MedicalInfo)");
            cmd.AddParameter("User_Id", file.User_id);
            cmd.AddParameter("PhoneNumber", file.PhoneNumber);
            cmd.AddParameter("Adress", file.Adress);
            cmd.AddParameter("BirthDate", file.Birthdate);
            cmd.AddParameter("MedicalInfo", file.MedicalInfo);

            _connection.ExecNonQuery(cmd);

        }

        public PatientFile? GetPatientFile(int id)
        {
            Command cmd = new Command("SELECT [User_Id], [PhoneNumber], [Adress], [BirthDate],[MedicalInfo] " +
                                        "FROM [dbo].[Patient] " +
                                        "WHERE [User_Id] = @Id");
            cmd.AddParameter("Id", id);

            return _connection.ExecReader(cmd, er => er.PatientDbToDal()).SingleOrDefault();
        }

        public void UpdatePatient (PatientFile file , int modifierId)
        {
            DateTime updateDate = DateTime.Now;

            Command cmd = new Command("UPDATE [dbo].[Patient] " +
                                        "SET [PhoneNumber] = @PhoneNumber , " +
                                        "[Adress] = @Adress , " +
                                        "[BirthDate] = @BirthDate , " +
                                        "[MedicalInfo] = @MedicalInfo " +
                                        "WHERE User_Id = @Id");

            cmd.AddParameter("PhoneNumber",file.PhoneNumber);
            cmd.AddParameter("Adress", file.Adress);
            cmd.AddParameter("BirthDate", file.Birthdate);
            cmd.AddParameter("MedicalInfo", file.MedicalInfo);
            cmd.AddParameter("Id", file.User_id);

            Command Hcmd = new Command("INSERT INTO [dbo].[Patient_Modification]([UpdateDate] , [Patient_Id] , [Employee_Id]) " +
                                         " VALUES (@UpdateDate , @Patient_Id , @User_id)");

            Hcmd.AddParameter("UpdateDate", updateDate);
            Hcmd.AddParameter("Patient_Id", file.User_id);
            Hcmd.AddParameter("User_Id", modifierId);

            _connection.ExecNonQuery(cmd);
            _connection.ExecNonQuery(Hcmd);
        }
    }
}
