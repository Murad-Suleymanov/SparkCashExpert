using Spark.Dal.Domain.Entities;
using Spark.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Models.Entities
{
    public class UserDTO : IBaseDTO
    {
        public int ID { get; set; }
        public string UserName { get; set; }

        public List<UserRoleDAO> Roles { get; set; }
    }
}
