using HospitalManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Mappers.Medic
{
   public static class MedicMapper
    {
        public static GotMedic MDbToDal( this IDataRecord record)
        {
            return new GotMedic()
            {
                Id = (int)record["Id"],
                FirstName = (string)record["FirstName"],
                LastName = (string)record["LastName"],
                Email = (string)record["Email"],
                Role = (string)record["RName"],
                Contract = (string)record["Contract"],
                HireDate = DateOnly.FromDateTime((DateTime)record["HireDate"]),
                ContractEnd = record["ContractEnd"] == DBNull.Value ? null : DateOnly.FromDateTime((DateTime)record["ContractEnd"]),
                Service = (string)record["SName"],
                Inami = (byte[])record["Inami"],
                Speciality = (string)record["Specialty"],
                Is_Subsized = (bool)record["Is_Subsized"]
            };
        }

        public static MedicLow MLDbToDal( this IDataRecord record)
        {
            return new MedicLow()
            {
                Id = (int)record["User_Id"],
                FirstName = (string)record["FirstName"],
                LastName = (string)record["LastName"],
                Specialty = (string)record["Specialty"],
                Is_Subsized = (bool)record["Is_Subsized"]
            };
        }
    }
}
