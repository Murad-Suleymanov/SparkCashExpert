using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Spark.BusinessLogich.Domain.Entities;
using Spark.Dal.Domain.Entities;
using Spark.Model.Abstract;

namespace Spark.Model
{
    public class InvoiceDetailDTO : IBaseDTO
    {
        public int ID { get; set; }
        public InvoiceDAO Invoice { get; set; }
        public ProductDTO Product { get; set; }
        public double Count { get; set; }
        public double CurrentPrice { get; set; }
        public double TotalSum => Count * CurrentPrice;
        public bool IsCanceled { get; set; }

        public static Task<InvoiceDetailDTO> ToDTO(InvoiceDetailDAO dAO)
        {
            Task.Run<InvoiceDetailDTO>(() =>
            {
                return new InvoiceDetailDTO
                {
                    ID = dAO.ID,
                    Count = dAO.Count,
                    CurrentPrice = dAO.CurrentPrice,
                    Product = ProductDTO.ToDTO(dAO.Product).GetAwaiter().GetResult(),
                    Invoice = dAO.Invoice,
                    IsCanceled = dAO.IsCanceled
                };
            });
            return null;
        }

        public static Task<ObservableCollection<InvoiceDetailDAO>> ToDAOS
           (ObservableCollection<InvoiceDetailDTO> dTOs)
        {
            return Task.Run<ObservableCollection<InvoiceDetailDAO>>(async () =>
             {
                 ObservableCollection<InvoiceDetailDAO> invoiceDetails = new ObservableCollection<InvoiceDetailDAO>();
                 foreach (var item in dTOs)
                 {
                     invoiceDetails.Add(new InvoiceDetailDAO
                     {
                         ID = item.ID,
                         Count = item.Count,
                         IsCanceled = item.IsCanceled,
                         CurrentPrice = item.CurrentPrice,
                         Invoice = item.Invoice,
                         Product = await ProductDTO.ToDAO(item.Product),
                         TotalSum = item.TotalSum
                     });
                 }
                 return invoiceDetails;
             });
        }

        public static Task<ObservableCollection<InvoiceDetailEntity>> ToEntities
           (ObservableCollection<InvoiceDetailDTO> dTOs)
        {
            return Task.Run<ObservableCollection<InvoiceDetailEntity>>(() =>
            {
                ObservableCollection<InvoiceDetailEntity> invoiceDetails = new ObservableCollection<InvoiceDetailEntity>();
                foreach (var item in dTOs)
                {
                    invoiceDetails.Add(new InvoiceDetailEntity
                    {
                        ID = item.ID,
                        Count = item.Count,
                        IsCanceled = item.IsCanceled,
                        CurrentPrice = item.CurrentPrice,
                        ProductName=item.Product.Name
                    });
                }
                return invoiceDetails;
            });
        }
    }
}
