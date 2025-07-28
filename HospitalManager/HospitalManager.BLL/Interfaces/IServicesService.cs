using HospitalManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.BLL.Interfaces
{
    public interface IServicesService
    {
        public List<Models.ServicesMod> getAllServices();
        public void addNewService(string name);

        public void deleteService(int id);
    }
}
