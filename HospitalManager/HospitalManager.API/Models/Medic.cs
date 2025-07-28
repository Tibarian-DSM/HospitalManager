namespace HospitalManager.API.Models
{
    public class Medic:Employee
    {
        public required string Inami { get; set; }
        public required string Speciality { get; set; }
        public required bool Is_Subsized { get; set; }
    }
}
