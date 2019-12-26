using Spark.Dal.Domain.Entities;
using System.Threading.Tasks;

namespace Spark.Dal.Domain.Abstract
{
    public interface IInvoiceDAORepository : IGenericDAORepository<InvoiceDAO>
    {
        Task<bool> InsertOrUpdate(InvoiceDAO obj);
    }
}
