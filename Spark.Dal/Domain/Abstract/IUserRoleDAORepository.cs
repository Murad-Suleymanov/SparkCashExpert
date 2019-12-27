using Spark.Dal.Domain.Entities;
using System.Threading.Tasks;

namespace Spark.Dal.Domain.Abstract
{
    interface IUserRoleDAORepository:IGenericDAORepository<UserRoleDAO>
    {
        Task<UserRoleDAO> GetUserRoleWithUserID(UserDAO userDAO);
    }
}
