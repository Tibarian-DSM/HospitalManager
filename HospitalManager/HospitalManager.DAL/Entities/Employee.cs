using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Entities
{
    public class Employee:User
    {
        public required string Contract { get; set; }
        public required DateOnly HireDate { get; set; }
        public DateOnly? ContractEnd {get; set; }
        public required int Service_Id {get; set;}
    }
}
