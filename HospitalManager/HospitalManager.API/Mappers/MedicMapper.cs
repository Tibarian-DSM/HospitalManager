using HospitalManager.API.Models.Dtos;

namespace HospitalManager.API.Mappers
{
    public static class MedicMapper
    {
        public static BLL.Models.Medic MApiToBll(this MedicForm medic)
        {
            return new BLL.Models.Medic()
            {
                FirstName = medic.FirstName,
                LastName = medic.LastName,
                Email = medic.Email,
                Password = medic.Password,
                Contract = medic.Contract,
                HireDate = medic.HireDate,
                ContractEnd = medic.ContractEnd,
                Service_Id = medic.Service_Id,
                Inami = medic.Inami,
                Speciality = medic.Speciality,
                Is_Subsized = medic.Is_Subsized
            };
        }

        public static Models.Medic MBllToApi(this BLL.Models.GotMedic medic)
        {
            return new Models.Medic()
            {
                Id = medic.Id,
                FirstName = medic.FirstName,
                LastName = medic.LastName,
                Email = medic.Email,
                Role = medic.Role,
                Contract = medic.Contract,
                HireDate = medic.HireDate,
                ContractEnd = medic.ContractEnd,
                Service = medic.Service,
                Inami = medic.Inami,
                Speciality = medic.Speciality,
                Is_Subsized = medic.Is_Subsized
            };
        }

        public static Models.MedicLow MLBLLToAPI(this BLL.Models.MedicLow medic)
        {
            return new Models.MedicLow()
            {
                Id = medic.Id,
                FirstName = medic.FirstName,
                LastName = medic.LastName,
                Specialty = medic.Specialty,
                Is_Subsized = medic.Is_Subsized
            };

        }
    }
}
