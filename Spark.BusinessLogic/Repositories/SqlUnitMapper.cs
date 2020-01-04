using Spark.BLL.Mappers.Abstraction;

namespace Spark.BLL.Repositories
{
    public class SqlUnitMapper : IUnitMapper
    {
        public IProductMapper ProductMapper => new ProductMapper();
    }
}
