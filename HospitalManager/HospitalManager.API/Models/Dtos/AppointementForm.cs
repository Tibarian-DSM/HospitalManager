using System.ComponentModel.DataAnnotations;

namespace HospitalManager.API.Models.Dtos
{
    public class AppointementForm
    {
        [Required]
        public DateTime Appointement_Date { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Subject { get; set; }
        [Required]
        public int Medic_Id { get; set; }
        [Required]
        public int Patient_Id { get; set; }
    }
}
