using HospitalManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Interfaces
{
    public interface IUserRepository
    {
        public GotUser getUserById(int id);
        public List<GotUser> getUsersByRole(string role);
        public string queryNextId();
    }
}
