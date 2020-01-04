using Spark.Dal.Domain.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Spark.Dal.Domain.Abstract
{
    public interface IProductDAORepository : IGenericDAORepository<ProductDAO>
    {
        Task<ProductDAO> GetByBarcode(string barcode);
        Task<List<ProductDAO>> GetProductsLikeBarcode(string barcode);
        Task<ObservableCollection<ProductDAO>> GetProductsLikeSearchString(string barcode);
    }
}
