using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.BLL.Mappers
{
    public static class AppointementMapper
    {
        public static DAL.Entities.Appointement ApBllToDal( this Models.Appointement appointement)
        {
            return new DAL.Entities.Appointement()
            {
                Appointement_Date = appointement.Appointement_Date,
                Subject = appointement.Subject,
                Medic_Id = appointement.Medic_Id,
                Patient_Id = appointement.Patient_Id,
            };
        }

        public static Models.GotAppointement ApDalToBll(this DAL.Entities.GotAppointement appointement)
        {
            return new Models.GotAppointement()
            {
                Id = appointement.Id,
                Appointement_Date = appointement.Appointement_Date,
                Subject = appointement.Subject,
                MedicFirstName = appointement.MedicFirstName,
                MedicLastName = appointement.MedicLastName,
                PatientFirstName = appointement.PatientFirstName,
                PatientLastName = appointement.PatientLastName
            };
        }
    }
}
