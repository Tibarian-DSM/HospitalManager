using HospitalManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Interfaces
{
    public interface IAppointementRepository
    {
        public void createAppointement(Appointement appointement);

        public GotAppointement GetAppointementById(int id);

        public List<GotAppointement> GetAppointementsByPatientId(int id);

        public List<GotAppointement> GetAppointementsByMedicId(int id);

    }
}
