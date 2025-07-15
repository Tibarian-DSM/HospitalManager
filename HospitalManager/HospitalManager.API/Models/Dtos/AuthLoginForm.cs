using System.ComponentModel.DataAnnotations;

namespace HospitalManager.API.Models.Dtos
{
    public class AuthLoginForm
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
