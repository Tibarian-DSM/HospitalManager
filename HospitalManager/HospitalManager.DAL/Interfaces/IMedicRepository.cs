using HospitalManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Interfaces
{
    public interface IMedicRepository
    {
        public void addNewMedic(Medic medic);
        public GotMedic GetMedicDetails(int id);

        public List<MedicLow> GetMedicsByService(int serviceId);
    }
}
