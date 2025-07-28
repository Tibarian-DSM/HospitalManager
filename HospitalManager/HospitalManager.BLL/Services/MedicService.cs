using HospitalManager.BLL.Interfaces;
using HospitalManager.BLL.Mappers;
using HospitalManager.BLL.Models;
using HospitalManager.DAL.Entities;
using HospitalManager.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.BLL.Services
{
    public class MedicService : IMedicService
    {
        private IMedicRepository _medicRepository;
        private IUserRepository _userRepository;

        public  MedicService(IUserRepository userRepository ,IMedicRepository medicRepository )
        { 
            _medicRepository = medicRepository;
            _userRepository = userRepository;
        }

        public void addNewMedic(Models.Medic medic)
        {
            // Hashage du mot de passe via BCrypt
            string hashPsw = BCrypt.Net.BCrypt.HashPassword(medic.Password);
            medic.Password = hashPsw;
            _medicRepository.addNewMedic(medic.MedBllToDal(_userRepository.queryNextId()));
        }

        public Models.GotMedic GetMedicDetails(int id)
        {
            return _medicRepository.GetMedicDetails(id).MDalToBll();
        }

        public List<Models.MedicLow> GetMedicsByService(int serviceId)
        {
            List<Models.MedicLow> medics = new List<Models.MedicLow>();

            if(_medicRepository.GetMedicsByService(serviceId) != null && _medicRepository.GetMedicsByService(serviceId).Count>0)
            {
                foreach(DAL.Entities.MedicLow medic in _medicRepository.GetMedicsByService(serviceId))
                {
                    medics.Add(medic.MLDalToBLL());
                }
            }

            return medics;
        }
    }
}
