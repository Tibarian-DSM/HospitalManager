using System.ComponentModel.DataAnnotations;

namespace HospitalManager.API.Models.Dtos
{
    public class AuthRegisterForm
    {
        [Required]
        [MinLength(1)]
        [MaxLength(25)]
        public required string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(25)]
        public required string LastName { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(25)]

        // regex : adresse mail , @ obligatoire , point necessaire pour l'extension et extension minimun 2 lettre
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Adresse email invalide.")]
        public required string Email { get; set; }

        [Required]
        // regex : au moins 1 minuscule , 1 majuscule , 1 chiffre et 1 caractère spécial
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Le mot de passe invalid")]
        public  required string Password { get; set; }
    }
}
