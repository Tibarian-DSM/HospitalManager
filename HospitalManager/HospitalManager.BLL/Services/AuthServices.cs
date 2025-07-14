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
        public void RegisterUser(User user)
        {
           string hashPsw = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hashPsw;
            _authRepository.RegisterUser(user.BLLToDal());
        }
    }
}
