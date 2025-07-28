using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.BLL.Interfaces
{
    public interface IAppointementService
    {
        public void createAppointement(Models.Appointement appointement);

        public Models.GotAppointement GetAppointementById(int id);

        public List<Models.GotAppointement> GetAppointementsByPatientId(int id);

        public List<Models.GotAppointement> GetAppointementsByMedicId(int id);
    }
}
