namespace HospitalManager.API.Models
{
    public class MedicLow
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Specialty { get; set; }
        public required bool Is_Subsized { get; set; }
    }
}
