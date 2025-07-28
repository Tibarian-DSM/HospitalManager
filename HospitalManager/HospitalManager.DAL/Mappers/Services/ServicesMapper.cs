using HospitalManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Mappers.Services
{
    public static class ServicesMapper
    {
        public static ServiceMod SDbToDal( this IDataRecord record)
        {
            return new ServiceMod()
            {
                Id = (int)record["Id"],
                Name = (string)record["Name"]
            };
        }

    }
}
