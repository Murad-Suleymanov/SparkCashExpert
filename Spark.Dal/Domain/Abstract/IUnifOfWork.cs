namespace Spark.Dal.Domain.Abstract
{
    public interface IUnifOfWork
    {
        IProductDAORepository ProductDAORepository { get; }
        IInvoiceDAORepository InvoiceDAORepository { get; }
        IInvoiceDetailDAORepository InvoiceDetailDAORepository { get; }
        IUserDAORepository UserDAORepository { get; }
    }
}
