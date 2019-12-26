using Spark.Dal.Domain.Entities;
using System.Threading.Tasks;

namespace Spark.Dal.Domain.Abstract
{
    public interface IInvoiceDetailDAORepository : IGenericDAORepository<InvoiceDetailDAO>
    {
        Task<bool> InsertOrUpdate(InvoiceDetailDAO obj);
    }
}
