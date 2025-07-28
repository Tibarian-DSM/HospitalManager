using HospitalManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Mappers
{
    public static class AppointementMapper
    {
        public static GotAppointement ApDbToDal(this IDataRecord record)
        {
            return new GotAppointement()
            {
                Id = (int)record["Id"],
                Appointement_Date = (DateTime)record["Appointement_Date"],
                Subject = record["Subject"].ToString(),
                MedicFirstName = record["MFirstName"].ToString(),
                MedicLastName = record["MLastName"].ToString(),
                PatientFirstName = record["PFirstName"].ToString(),
                PatientLastName = record["PLastName"].ToString()
            };
        }


    }
}
