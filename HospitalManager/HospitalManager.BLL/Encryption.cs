using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HospitalManager.BLL
{
    public static class Encryption
    {
        private static Dictionary<string, string> _paths;

        //Clé Aes du dictionnaire encrypter
        private static string ivKeyPath;

        // L'iv du dictionnaire
        private static string ivDictPath;

        // Le fichier Json encrypté
        private static string DictionaryIvPath;

        #region Chargement des différent chemin de fichier
        public static void init(Dictionary<string, string> paths)
        {
            _paths = paths;

            ivKeyPath = _paths["IvKeyPath"];
            ivDictPath = _paths["IvDictPath"];
            DictionaryIvPath = _paths["DictionaryIvPath"]; ;
        }
        #endregion

        #region fonction de chiffrage des données
        public static byte[] Encrypt(string info, byte[] key, byte[] iv)
        {
            byte[] cipher;

            // Création d’un objet AES
            using (Aes aes = Aes.Create())
            {
                // Création d’un transformateur de chiffrement avec la clé et le vecteur d’initialisation (IV)
                ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);
                using (MemoryStream ms = new MemoryStream())
                {
                    // Flux de chiffrement AES écrit dans la mémoire
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        // Écriture du texte à chiffrer dans le flux, en UTF-8
                        using (StreamWriter sw = new StreamWriter(cs, Encoding.UTF8))
                        {
                            sw.Write(info);
                        }
                        // On récupère les données chiffrées dans le buffer mémoire
                        cipher = ms.ToArray();
                    }
                }
            }
            return cipher;
        }

        #endregion

        #region fonction de déchiffrage des données
        public static string Decrypt(byte[] cipher, byte[] key, byte[] iv)
        {
            string info;

            using (Aes aes = Aes.Create())
            {
                // Création d’un transformateur de déchiffrement avec la clé et le vecteur d’initialisation (IV)
                ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);
                using (MemoryStream ms = new MemoryStream(cipher))
                {
                    // Flux de chiffrement AES lit dans la mémoire
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        // Lecture du texte à déchiffrer dans le flux, en UTF-8
                        using (StreamReader sr = new StreamReader(cs, Encoding.UTF8))
                        {
                            info = sr.ReadToEnd();
                        }

                    }
                }
            }
            return info;
        }
        #endregion

        #region Enregistrement du dictionnaire nécessaire à la lecture des info crypter de utilisateur

        public static void SaveIvDictionary(Dictionary<string, string> dict)
        {
            if (!File.Exists(ivKeyPath) || !File.Exists(DictionaryIvPath))
            {
                throw new FileNotFoundException("Un des fichiers de chiffrement est introuvable.");
            }

            byte[] ivAesKey = File.ReadAllBytes(ivKeyPath);
            byte[] currentIV = File.ReadAllBytes(DictionaryIvPath);

            string json = JsonSerializer.Serialize(dict, new JsonSerializerOptions { WriteIndented = true });
            byte[] cipher;

            using (Aes aes = Aes.Create())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(ivAesKey, currentIV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs, Encoding.UTF8))
                        {
                            sw.Write(json);
                        }
                        cipher = ms.ToArray();
                    }
                }
            }

            File.WriteAllBytes(ivDictPath, cipher);

        }
        #endregion

        #region Chargement du dictionnaire nécessaire à la lecture des info crypter de utilisateur

        public static Dictionary<string, string> getIvDictonnary()
        {
            Dictionary<string, string> ivDictonary = new Dictionary<string, string>();

            if (!File.Exists(ivKeyPath) || !File.Exists(DictionaryIvPath))
            {
                throw new FileNotFoundException("Un des fichiers de chiffrement est introuvable.");
            }

            if (!File.Exists(ivDictPath))
            {
                SaveIvDictionary(ivDictonary);
            }

            byte[] ivAesKey = File.ReadAllBytes(ivKeyPath);
            byte[] currentIV = File.ReadAllBytes(DictionaryIvPath);
            byte[] jsonCrypted = File.ReadAllBytes(ivDictPath);

            string jsonDecrypted;

            using (Aes aes = Aes.Create())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(ivAesKey, currentIV);
                using (MemoryStream ms = new MemoryStream(jsonCrypted))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs, Encoding.UTF8))
                        {
                            jsonDecrypted = sr.ReadToEnd();

                            ivDictonary = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonDecrypted) ?? new Dictionary<string, string>();
                        }

                    }
                }


            }

            return ivDictonary;
        }
        #endregion
    }
}
