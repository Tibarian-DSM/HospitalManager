using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Entities
{
    public class PatientFile 
    {
        public int User_id{ get; set; }
        public required byte[] PhoneNumber { get; set; }
        public required byte[] Adress { get; set; }
        public required byte[] Birthdate { get; set; }
        public required byte[] MedicalInfo { get; set; }

    }
}
