using HospitalManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Mappers.AuthMapper
{
    public static class GotUserMapper
    {
        public static GotUser DbToDal(this IDataRecord record)
        {
            return new GotUser()
            {
                Id = (int)record["Id"],
                FirstName = record["FirstName"].ToString(),
                LastName = record["LastName"].ToString(),
                Email = record["Email"].ToString(),
                Role = record["Name"].ToString()
            };
        }

    }
}
