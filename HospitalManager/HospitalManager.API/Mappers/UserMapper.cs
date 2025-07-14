using HospitalManager.API.Models.Dtos;
using HospitalManager.BLL.Models;
using System.Reflection.Metadata.Ecma335;

namespace HospitalManager.API.Mappers
{
    public static class UserMapper
    {
        public static User ApiToBll(AuthRegisterForm form)
        {
            return new User()
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                Password = form.Password
            };
        }
    }
}
