using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.BLL.Models
{
    public class GotMedic : GotUser
    {
        public required string Contract { get; set; }
        public required DateOnly HireDate { get; set; }
        public DateOnly? ContractEnd { get; set; }
        public required string Service { get; set; }
        public required string Inami { get; set; }
        public required string Speciality { get; set; }
        public required bool Is_Subsized { get; set; }
    }
}
