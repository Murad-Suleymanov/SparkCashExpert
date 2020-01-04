using Spark.Dal.Domain.Entities;
using System.Collections.Generic;

namespace Spark.Login.Model
{
    public class User 
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<UserRoleDAO> Roles { get; set; }
    }
}
