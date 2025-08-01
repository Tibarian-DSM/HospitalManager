﻿using HospitalManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Interfaces
{
    public interface IPatientRepository
    {

        public PatientFile? GetPatientFile(int id);
        public void AddNewPatientFile(PatientFile file);

        public void UpdatePatient(PatientFile file, int modifierId);
    }
}
