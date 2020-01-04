using Spark.Dal.Domain.Entities;
using Spark.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Spark.BLL.Mappers.Abstraction
{
    public interface IProductMapper : IMapper<ProductDTO, ProductDAO>
    {
        Task<ObservableCollection<ProductDTO>> MapToDTOList(ObservableCollection<ProductDAO> productDAO);
    }
}
