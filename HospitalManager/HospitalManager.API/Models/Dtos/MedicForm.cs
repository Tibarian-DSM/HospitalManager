using System.ComponentModel.DataAnnotations;

namespace HospitalManager.API.Models.Dtos
{
    public class MedicForm:EmployeeForm
    {
        [Required]
        [MaxLength(11)]
        [RegularExpression(@"^\d{11}$")]
        public required string Inami { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Speciality { get; set; }
        
        [Required]
        public required bool Is_Subsized { get; set; }
    }
}
