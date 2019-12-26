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
        public int? Count { get; set; }
        [Display(Name ="Alis qiymeti")]
        public double? PurschasePrice { get; set; }
        [Display(Name = "Satis qiymeti")]
        public double SellPrice { get; set; }
    }
}
