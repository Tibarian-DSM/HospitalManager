using HospitalManager.BLL.Interfaces;
using HospitalManager.BLL.Mappers;
using HospitalManager.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.BLL.Services
{
    public class PatientService : IPatientServices
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public void AddNewPatientFile(Models.PatientFile patientFile)
        {
            _patientRepository.AddNewPatientFile(patientFile.BllToDal());
        }

        public Models.PatientFile? GetPatient(int id)
        {
            DAL.Entities.PatientFile? patient = _patientRepository.GetPatientFile(id);

            if (patient == null)
            {
                return null;
            }

            return patient.DalToBll();
        }
    }
}
