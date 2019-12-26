using Spark.Dal.Domain.Entities;
using System.Threading.Tasks;

namespace Spark.Dal.Domain.Abstract
{
    public interface IUserDAORepository:IGenericDAORepository<UserDAO>
    {
        Task<UserDAO> GetUser(string username);
    }
}
