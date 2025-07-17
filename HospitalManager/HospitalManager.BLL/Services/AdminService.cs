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
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository repo)
        {
            _adminRepository = repo;
        }

        public List<Models.GotUser> GetAll()
        {
            List<Models.GotUser> users = new List<Models.GotUser>();

            foreach (DAL.Entities.GotUser u in _adminRepository.GetAll())
            {
                users.Add(u.DalToBLL());
            }
            if (users is null)
            {
                throw new NullReferenceException();
            }
            return users;
        }
    }
}
