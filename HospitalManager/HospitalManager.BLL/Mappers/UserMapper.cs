using HospitalManager.BLL.Models;
using HospitalManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace HospitalManager.BLL.Mappers
{
    public static class UserMapper
    {
        public static DAL.Entities.User BLLToDal(this BLL.Models.User user)
        {
            return new DAL.Entities.User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
            };
        }

        public static BLL.Models.GotUser DalToBLL(this DAL.Entities.GotUser user)
        {
            return new BLL.Models.GotUser()
            {   Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role
            };
        }
    
    }
}
