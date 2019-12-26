using Spark.Dal.Domain.Abstract;

namespace Spark.Dal.Domain.Entities
{
    public class ProductTypeDAO : IBaseDAO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public StoreDAO Store { get; set; }
    }
}
