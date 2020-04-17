using Spark.BusinessLogich.Domain.Entities;
using System.Collections.ObjectModel;

namespace Spark.BusinessLogich.Report
{
    public class Sender
    {
        /// <summary>
        /// For send InvoiceDetails to Report application
        /// </summary>
        /// <param name="invoiceDetails"></param>
        /// <param name="username"></param>
        /// <returns>ObservableCollection<InvoiceDetailEntity></returns>
        public static ObservableCollection<InvoiceDetailEntity> InvoiceDetails
            (ObservableCollection<InvoiceDetailEntity> invoiceDetails, string username)
        {
            if (invoiceDetails != null)
                invoiceDetails[0].UserName = username;
            return invoiceDetails;
        }
    }
}
