using Spark.Dal.Models;
using Spark.Dal.Models.CodeFirstFromDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Dal.Mappers.Abstract
{
    public interface IProductMapper : IGenericMapper<Product, ProductDAO>
    {
        ProductDAO ConvertToProductDAO(Product product);
        Product ConvertToProduct(ProductDAO productDAO);
    }
}
