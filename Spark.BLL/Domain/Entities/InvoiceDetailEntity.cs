namespace Spark.BLL.Domain.Entities
{
    class InvoiceDetailEntity
    {
        public int ID { get; set; }
        public double Count { get; set; }
        public double CurrentPrice { get; set; }
        public double TotalSum => Count * CurrentPrice;
        public bool IsCanceled { get; set; }
    }
}
