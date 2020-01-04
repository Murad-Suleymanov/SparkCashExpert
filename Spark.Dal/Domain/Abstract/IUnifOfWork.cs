namespace Spark.Dal.Domain.Abstract
{
    public interface IUnitOfWork
    {
        IProductDAORepository ProductDAORepository { get; }
        IInvoiceDAORepository InvoiceDAORepository { get; }
        IInvoiceDetailDAORepository InvoiceDetailDAORepository { get; }
        IUserDAORepository UserDAORepository { get; }
    }
}
