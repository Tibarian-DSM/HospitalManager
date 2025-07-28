using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.BLL.Mappers
{
    public static class ServiceMapper
    {
        public static Models.ServicesMod SDalToBll( this DAL.Entities.ServiceMod service)
        {
            return new Models.ServicesMod()
            {
                Id = service.Id,
                Name = service.Name
            };
        }
    }
}
