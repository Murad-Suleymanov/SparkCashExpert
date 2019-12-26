using Spark.Dal.Domain.Abstract;

namespace Spark.Dal.Domain.Entities
{
    public class InvoiceDetailDAO : IBaseDAO
    {
        public int ID { get; set; }
        public InvoiceDAO Invoice { get; set; }
        public ProductDAO Product { get; set; }
        public double Count { get; set; }
        public double CuurentPrice { get; set; }
        public double TotalSum { get; set; }
        public bool IsCanceled { get; set; }
    }
}