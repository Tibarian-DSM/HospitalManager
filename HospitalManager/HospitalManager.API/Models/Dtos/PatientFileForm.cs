using System.ComponentModel.DataAnnotations;

namespace HospitalManager.API.Models.Dtos
{
    public class PatientFileForm
    {
        [Required]
        [StringLength(15)]
        public required string PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        public required string Adress { get; set; }

        [Required]
        public required DateOnly Birthdate { get; set; }

        [Required]
        [StringLength(1500)]
        public required string MedicalInfo { get; set; }
    }
}
