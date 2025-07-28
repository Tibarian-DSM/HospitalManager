using HospitalManager.API.Models.Dtos;

namespace HospitalManager.API.Mappers
{
    public static class AppointementMapper
    {
        public static BLL.Models.Appointement ApApiToBll(this AppointementForm appointement)
        {
            return new BLL.Models.Appointement()
            {
                Appointement_Date = appointement.Appointement_Date,
                Subject = appointement.Subject,
                Medic_Id = appointement.Medic_Id,
                Patient_Id = appointement.Patient_Id,
            };
        }

        public static Models.Appointement ApBllToApi(this BLL.Models.GotAppointement appointement)
        {
            return new Models.Appointement()
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
