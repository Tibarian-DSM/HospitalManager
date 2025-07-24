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
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public GotUser getUserById(int id)
        {
            return _userRepository.getUserById(id).DalToBLL();
        }

        public List<GotUser> getUsersByRole(string role)
        {
           List<GotUser> users = new List<GotUser>();

            foreach (DAL.Entities.GotUser user in _userRepository.getUsersByRole(role))
            {
                users.Add(user.DalToBLL());
            }

            return users;
        }
    }
}
