using Spark.Dal.Mappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Dal.Mappers.Repositories
{
    public class GenericMapper<TTarget, TSource> : IGenericMapper<TTarget, TSource> where TTarget :class where TSource:class
    {  
    }
}
