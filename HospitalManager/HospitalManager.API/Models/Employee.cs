namespace HospitalManager.API.Models
{
    public class Employee:User
    {
        public required string Contract { get; set; }
        public required DateOnly HireDate { get; set; }
        public DateOnly? ContractEnd { get; set; }
        public required string Service { get; set; }
    }
}
