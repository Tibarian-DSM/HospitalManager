using HospitalManager.BLL.Models;
using HospitalManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.BLL.Interfaces
{
    public interface IPatientServices
    {
        public void AddNewPatientFile(Models.PatientFile patientFile);

        public Models.PatientFile? GetPatient(int id);
    }
}
