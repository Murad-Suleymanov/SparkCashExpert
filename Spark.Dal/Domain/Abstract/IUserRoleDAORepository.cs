using Spark.Dal.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spark.Dal.Domain.Abstract
{
    interface IUserRoleDAORepository:IGenericDAORepository<UserRoleDAO>
    {
        Task<List<UserRoleDAO>> GetUserRoleWithUserID(UserDAO userDAO);
    }
}
