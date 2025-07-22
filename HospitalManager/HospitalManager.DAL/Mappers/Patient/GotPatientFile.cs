using HospitalManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Mappers.Patient
{
    public static class GotPatientFile
    {

        public static PatientFile PatientDbToDal(this IDataRecord record)
        {

            return new PatientFile()
            {
                User_id = (int)record["User_id"],
                Adress = (byte[])record["Adress"],
                PhoneNumber = (byte[])record["PhoneNumber"],
                Birthdate = (byte[])record["BirthDate"],
                MedicalInfo = (byte[])record["MedicalInfo"]
            };
        }
    }
}
