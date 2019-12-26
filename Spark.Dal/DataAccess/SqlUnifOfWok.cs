using Spark.Dal.Domain.Abstract;

namespace Spark.Dal.DataAccess
{
    public class SqlUnifOfWork : IUnifOfWork
    {
        public IProductDAORepository ProductDAORepository => throw new System.NotImplementedException();

        public IInvoiceDAORepository InvoiceDAORepository => throw new System.NotImplementedException();

        public IInvoiceDetailDAORepository InvoiceDetailDAORepository => throw new System.NotImplementedException();

        public IUserDAORepository UserDAORepository => throw new System.NotImplementedException();
    }
}
