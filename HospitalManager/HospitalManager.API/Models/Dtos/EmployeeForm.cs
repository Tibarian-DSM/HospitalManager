using System.ComponentModel.DataAnnotations;

namespace HospitalManager.API.Models.Dtos
{
    public class EmployeeForm : AuthRegisterForm
    {
        [Required]
        [MaxLength(32)]
        public required string Contract { get; set; }
        [Required]
        public required DateOnly HireDate { get; set; }
        public DateOnly? ContractEnd { get; set; }
        [Required]
        public required int Service_Id { get; set; }
    }
}
