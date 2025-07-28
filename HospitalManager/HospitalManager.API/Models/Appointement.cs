namespace HospitalManager.API.Models
{
    public class Appointement
    {
        public int Id { get; set; }
        public DateTime Appointement_Date { get; set; }

        public required string Subject { get; set; }

        public required string MedicFirstName { get; set; }
        public required string MedicLastName { get; set; }

        public required string PatientFirstName { get; set; }
        public required string PatientLastName { get; set; }
    }
}
