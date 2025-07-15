using HospitalManager.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.BLL.Interfaces
{
    public interface IAuthService
    {
        void RegisterUser(User user);
        GotUser Login(string username, string password);
    }
}
