using Spark.Dal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Dal.Domain.Abstract
{
    public interface ITransaction
    {
        Task<bool> BeginTransactionAsync(InvoiceDAO invoiceDAO, ObservableCollection<InvoiceDetailDAO> detailDAOs);
    }
}
