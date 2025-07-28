using HospitalManager.BLL.Interfaces;
using HospitalManager.BLL.Mappers;
using HospitalManager.BLL.Models;
using HospitalManager.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.BLL.Services
{
    public class ServicesService : IServicesService
    {
        private readonly IServicesRepository _servicesRepository;

        public ServicesService(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }

        public void addNewService(string name)
        {
            _servicesRepository.addNewService(name);
        }

        public void deleteService(int id)
        {
            _servicesRepository.deleteService(id);
        }

        public List<Models.ServicesMod> getAllServices()
        {
            List<Models.ServicesMod> services = new List<Models.ServicesMod>();

            if( _servicesRepository.getAllServices() != null )
            {
                foreach(DAL.Entities.ServiceMod service in _servicesRepository.getAllServices())
                {
                    services.Add(service.SDalToBll());
                }
            }

            return services;
        }
    }
}
