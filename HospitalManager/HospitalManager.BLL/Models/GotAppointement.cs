using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.BLL.Models
{
   public class GotAppointement
    {
        public int Id { get; set; }
        public DateTime Appointement_Date { get; set; }

        public required string Subject { get; set; }

        public required string MedicFirstName { get; set; }
        public required string MedicLastName { get; set; }

        public required string PatientFirstName { get; set; }
        public required string PatientLastName { get; set; }
    }
}
