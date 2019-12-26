using Spark.Dal.Mappers.Abstract;
using Spark.Dal.Models;
using Spark.Dal.Models.CodeFirstFromDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Dal.Mappers.Repositories
{
    public class ProductMapper : GenericMapper<Product, ProductDAO>, IProductMapper
    {
        public Product ConvertToProduct(ProductDAO productDAO)
        {
            throw new NotImplementedException();
        }

        public ProductDAO ConvertToProductDAO(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
