using HospitalManager.BLL.Models;
using System.Security.Cryptography;
using HospitalManager.BLL;
using System.Text.Json;
using System.IO;

namespace HospitalManager.BLL.Mappers
{
    public static class PatientFileMapper
    {
        private static Dictionary<string, string> _paths;

        private static string _keyPath;
        private static byte[] _aesKey;

        public static void init(Dictionary<string, string> paths)
        {
            _paths = paths;

            _keyPath = _paths["PatientKeyPath"];
            _aesKey= File.ReadAllBytes(_keyPath);
        }

        public static DAL.Entities.PatientFile BllToDal( this PatientFile file)
        {
            byte[] patientIv;
            using (Aes aes = Aes.Create())
            {
               aes.GenerateIV();
                patientIv=aes.IV;
            }

            Dictionary<string, string> ivDict = Encryption.getIvDictonnary();

            string newKey = file.User_id.ToString();
            string newIvValue = Convert.ToBase64String(patientIv);

            ivDict[newKey] = newIvValue;

            Encryption.SaveIvDictionary(ivDict);

            return new DAL.Entities.PatientFile()
                {
                   User_id = file.User_id,
                   PhoneNumber = Encryption.Encrypt(file.PhoneNumber,_aesKey,patientIv),
                   Adress=Encryption. Encrypt(file.Adress,_aesKey,patientIv),
                   Birthdate=Encryption.Encrypt(file.Birthdate.ToString("dd/MM/yyyy"),_aesKey,patientIv),
                   MedicalInfo=Encryption.Encrypt(file.MedicalInfo,_aesKey,patientIv),
                };
        }

        public static PatientFile DalToBll(this DAL.Entities.PatientFile file)
        {
            Dictionary<string, string> ivDict = Encryption.getIvDictonnary();

            string userIdKey = file.User_id.ToString();

            if (!ivDict.ContainsKey(userIdKey))
            {
                throw new KeyNotFoundException($"Aucun IV correspondant trouvé.");
            }

            byte[] patientIv = Convert.FromBase64String(ivDict[userIdKey]);

            return new PatientFile()
            {
                User_id = file.User_id,
                PhoneNumber = Encryption.Decrypt(file.PhoneNumber, _aesKey, patientIv),
                Adress = Encryption.Decrypt(file.Adress, _aesKey, patientIv),
                Birthdate = DateOnly.ParseExact(Encryption.Decrypt(file.Birthdate, _aesKey, patientIv),"dd/MM/yyyy"),
                MedicalInfo = Encryption.Decrypt(file.MedicalInfo, _aesKey, patientIv),
            };
        }

        public static DAL.Entities.PatientFile UpdateBllToDal(this PatientFile file)
        {

            Dictionary<string, string> ivDict = Encryption.getIvDictonnary();

            string userIdKey = file.User_id.ToString();

            if (!ivDict.ContainsKey(userIdKey))
            {
                throw new KeyNotFoundException($"Aucun IV correspondant trouvé.");
            }

            byte[] patientIv = Convert.FromBase64String(ivDict[userIdKey]);

            return new DAL.Entities.PatientFile()
            {
                User_id = file.User_id,
                PhoneNumber = Encryption.Encrypt(file.PhoneNumber, _aesKey, patientIv),
                Adress = Encryption.Encrypt(file.Adress, _aesKey, patientIv),
                Birthdate = Encryption.Encrypt(file.Birthdate.ToString("dd/MM/yyyy"), _aesKey, patientIv),
                MedicalInfo = Encryption.Encrypt(file.MedicalInfo, _aesKey, patientIv),
            };
        }

    }   
}
