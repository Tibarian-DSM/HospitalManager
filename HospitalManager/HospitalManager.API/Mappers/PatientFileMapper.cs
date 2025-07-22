using HospitalManager.API.Models.Dtos;
using HospitalManager.BLL.Models;

namespace HospitalManager.API.Mappers
{
    public static class PatientFileMapper
    {
        public static PatientFile ApiToBll(this PatientFileForm form , int id)
        {
            return new PatientFile()
            {
                User_id = id,
                PhoneNumber = form.PhoneNumber,
                Adress = form.Adress,
                Birthdate = form.Birthdate,
                MedicalInfo = form.MedicalInfo

            };
        }

        public static Models.PatientFile BllToApi(this BLL.Models.PatientFile patient)
        {
            return new Models.PatientFile()
            {
                User_id = patient.User_id,
                PhoneNumber = patient.PhoneNumber,
                Adress = patient.Adress,
                Birthdate = patient.Birthdate,
                MedicalInfo = patient.MedicalInfo
            };
        }

    }
}
