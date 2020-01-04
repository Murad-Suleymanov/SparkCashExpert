using System.Threading.Tasks;

namespace Spark.BLL.Mappers.Abstraction
{
    public interface IMapper<TTarget,TSource> where TTarget: class where TSource: class  
    {
        Task<TTarget> ConvertToTarget(TSource source);
    }
}
