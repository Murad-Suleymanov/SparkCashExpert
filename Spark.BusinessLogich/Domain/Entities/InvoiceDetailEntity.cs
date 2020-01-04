using Spark.BusinessLogich.Domain.Abstract;

namespace Spark.BusinessLogich.Domain.Entities
{
    public class InvoiceDetailEntity:IBaseEntity
    {
        public int ID { get; set; }
        public double Count { get; set; }
        public double CurrentPrice { get; set; }
        public double TotalSum => Count * CurrentPrice;
        public bool IsCanceled { get; set; }
    }
}
