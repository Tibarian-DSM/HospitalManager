namespace HospitalManager.API.Models
{
    public class PatientFile
    {
        public int User_id { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Adress { get; set; }
        public required DateOnly Birthdate { get; set; }
        public required string MedicalInfo { get; set; }
    }
}
