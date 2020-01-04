using Spark.BusinessLogich.Domain.Entities;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Spark.BusinessLogich.Calculating
{
    public class Calculate
    {
        public static Task<double> TotalSum(ObservableCollection<InvoiceDetailEntity> invoiceDetails)
        {
            return Task.Run<double>(() =>
            {
                double sum = 0;
                if (invoiceDetails != null)
                {
                    foreach (var item in invoiceDetails)
                    {
                        if (!item.IsCanceled)
                        {
                            sum += item.TotalSum;
                        }
                    }
                }
                return sum;
            });
        }
    }
}
