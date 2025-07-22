using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.BLL.Models
{
    public class PatientFile
    {
        public int User_id { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Adress { get; set; }
        public required DateOnly Birthdate { get; set; }
        public required string MedicalInfo { get; set; }
    }
}
