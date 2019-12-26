using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Dal.Mappers.Abstract
{
    public interface IUnitOfWork
    {
        IProductMapper ProductMapper { get; }
    }
}
