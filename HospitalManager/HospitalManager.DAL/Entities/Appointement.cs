using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Entities
{
    public class Appointement
    {
        public DateTime Appointement_Date { get; set; }

        public string Subject { get; set; }

        public  int Medic_Id { get; set; }

        public int Patient_Id { get; set; }

    }
}
