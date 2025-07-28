using System.ComponentModel.DataAnnotations;

namespace HospitalManager.API.Models
{
    public class ServicesMod
    {
        public int? Id { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
    }
}
