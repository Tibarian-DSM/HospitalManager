using HospitalManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using HospitalManager.DAL.Interfaces;

namespace HospitalManager.BLL.Mappers
{
    public static class MedicMapper
    {
        private static Dictionary<string, string> _paths;

        private static string _keyPath;
        private static byte[] _aesKey;
  

        public static void init(Dictionary<string, string> paths)
        {
            _paths = paths;

            _keyPath = _paths["EmployeeKeyPath"];
            _aesKey = File.ReadAllBytes(_keyPath);

        }
        public static DAL.Entities.Medic MedBllToDal(this Models.Medic medic , string nextId)
        {
            byte[] medicIv;
            using (Aes aes = Aes.Create())
            {
                aes.GenerateIV();
                medicIv = aes.IV;
            }

            Dictionary<string, string> ivDict = Encryption.getIvDictonnary();

            string newKey = nextId;
            string newIvValue = Convert.ToBase64String(medicIv);

            ivDict[newKey] = newIvValue;

            Encryption.SaveIvDictionary(ivDict);

            return new DAL.Entities.Medic()
            {
                FirstName = medic.FirstName,
                LastName = medic.LastName,
                Email = medic.Email,
                Password = medic.Password,
                Contract = medic.Contract,
                HireDate = medic.HireDate,
                ContractEnd=medic.ContractEnd,
                Service_Id = medic.Service_Id,
                Inami = Encryption.Encrypt(medic.Inami, _aesKey, medicIv),
                Speciality = medic.Speciality,
                Is_Subsized = medic.Is_Subsized,
            };
        }

        public static Models.GotMedic MDalToBll(this DAL.Entities.GotMedic medic)
        {
            Dictionary<string, string> ivDict = Encryption.getIvDictonnary();

            string userIdKey =medic.Id.ToString();

            if (!ivDict.ContainsKey(userIdKey))
            {
                throw new KeyNotFoundException($"Aucun IV correspondant trouvé.");
            }

            byte[] medicIv = Convert.FromBase64String(ivDict[userIdKey]);

            return new Models.GotMedic()
            {
                Id = medic.Id,
                FirstName = medic.FirstName,
                LastName = medic.LastName,
                Email = medic.Email,
                Role = medic.Role,
                Contract = medic.Contract,
                HireDate = medic.HireDate,
                ContractEnd = medic.ContractEnd,
                Service = medic.Service,
                Inami = Encryption.Decrypt(medic.Inami, _aesKey, medicIv),
                Speciality = medic.Speciality,
                Is_Subsized = medic.Is_Subsized,
            };

        }

        public static Models.MedicLow MLDalToBLL(this DAL.Entities.MedicLow medic)
        {
            return new Models.MedicLow()
            {
                Id = medic.Id,
                FirstName = medic.FirstName,
                LastName = medic.LastName,
                Specialty = medic.Specialty,
                Is_Subsized = medic.Is_Subsized
            };

        }

    }
}
