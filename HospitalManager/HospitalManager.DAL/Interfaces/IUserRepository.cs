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
        GotUser getUserById(int id);
        List<GotUser> getUsersByRole(string role);
    }
}
