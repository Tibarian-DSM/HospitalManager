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
    public class AppointementService : IAppointementService
    {
        private readonly IAppointementRepository _repository;

        public AppointementService(IAppointementRepository repository)
        {
            _repository = repository;
        }
        public void createAppointement(Appointement appointement)
        {
            _repository.createAppointement(appointement.ApBllToDal());
        }

        public GotAppointement GetAppointementById(int id)
        {
            return _repository.GetAppointementById(id).ApDalToBll();
        }

        public List<Models.GotAppointement> GetAppointementsByMedicId(int id)
        {
           List<Models.GotAppointement> appointements = new List<GotAppointement> ();

            if(_repository.GetAppointementsByMedicId(id) != null && _repository.GetAppointementsByMedicId(id).Count() > 0)
            {
                foreach(DAL.Entities.GotAppointement ap in _repository.GetAppointementsByMedicId(id))
                {
                    appointements.Add(ap.ApDalToBll());
                }
            }

            return appointements;
        }

        public List<GotAppointement> GetAppointementsByPatientId(int id)
        {
            List<Models.GotAppointement> appointements = new List<GotAppointement>();

            if (_repository.GetAppointementsByPatientId(id) != null && _repository.GetAppointementsByPatientId(id).Count() > 0)
            {
                foreach (DAL.Entities.GotAppointement ap in _repository.GetAppointementsByPatientId(id))
                {
                    appointements.Add(ap.ApDalToBll());
                }
            }

            return appointements;
        }
    }
}
