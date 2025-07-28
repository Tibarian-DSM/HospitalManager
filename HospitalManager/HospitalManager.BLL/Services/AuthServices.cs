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
    public class AuthServices : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthServices(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public GotUser Login(string email, string password)
        {
            try
            {
                string hashedPsw = _authRepository.GetPassword(email);
                //Comparaison du mot de passe hashé et celui qu'on vient de rentré 
                if(!BCrypt.Net.BCrypt.Verify(password,hashedPsw))
                    {
                        throw new Exception("Incorrect password");
                    }
                BLL.Models.GotUser user = _authRepository.GetUserByEmail(email).DalToBLL();

                return user;

            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentException("Email incorrect");
            }
        }

        public void RegisterUser(User user)
        {
            // Hashage du mot de passe via BCrypt
           string hashPsw = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hashPsw;
            _authRepository.RegisterUser(user.BLLToDal());
        }
    }
}
