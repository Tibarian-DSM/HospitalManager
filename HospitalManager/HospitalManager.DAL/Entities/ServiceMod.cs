using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Entities
{
   public class ServiceMod
    {
        public int? Id { get; set; }
        public required string Name { get; set; }
    }
}
