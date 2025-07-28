using HospitalManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Interfaces
{
    public interface IServicesRepository
    {
        public List<ServiceMod> getAllServices();
        public void addNewService(string name);

        public void deleteService(int id);

    }
}
