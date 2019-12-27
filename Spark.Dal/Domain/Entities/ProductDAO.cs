using Spark.Dal.Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Spark.Dal.Domain.Entities
{
    public class ProductDAO : IBaseDAO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ProductTypeDAO ProductType { get; set; }
        public string Barcode { get; set; }
        public double? Count { get; set; }
        public double? PurschasePrice { get; set; }
        public double SellPrice { get; set; }
    }
}
