using HospitalManager.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.BLL.Interfaces
{
    public interface IMedicService
    {
        public void addNewMedic(Medic medic);

        public Models.GotMedic GetMedicDetails(int id);

        public List<Models.MedicLow> GetMedicsByService(int serviceId);
    }
}
