using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Spark.Dal.Domain.Abstract
{
    public interface IGenericDAORepository<T> where T : class
    {
        Task<T> GetByID(int id);
        Task<T> GetFromReader(SqlDataReader rdr);
    }
}
