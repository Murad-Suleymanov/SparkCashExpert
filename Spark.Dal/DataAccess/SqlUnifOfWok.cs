using Spark.Dal.Domain.Abstract;

namespace Spark.Dal.DataAccess
{
    public class SqlUnifOfWork : IUnitOfWork
    {
        public IProductDAORepository ProductDAORepository => new SqlProductDAORepository(new SqlContext());

        public IInvoiceDAORepository InvoiceDAORepository => new SqlInvoiceDAORepository(new SqlContext());

        public IInvoiceDetailDAORepository InvoiceDetailDAORepository => new SqlInvoiceDetailDAORepository(new SqlContext());

        public IUserDAORepository UserDAORepository => new SqlUserDAORepository(new SqlContext());
    }
}
