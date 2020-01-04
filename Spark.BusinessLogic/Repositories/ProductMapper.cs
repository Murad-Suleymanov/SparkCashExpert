using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Spark.BLL.Mappers.Abstraction;
using Spark.Dal.Domain.Entities;
using Spark.Model;

namespace Spark.BLL.Repositories
{
    public class ProductMapper : IProductMapper
    {

        public Task<ProductDTO> ConvertToTarget(ProductDAO source)
        {
            Task.Run<ProductDTO>(() =>
            {
                return new ProductDTO
                {
                    ID = source.ID,
                    Barcode = source.Barcode,
                    Price = source.SellPrice,
                    Name = source.Name
                };
            });
            return null;
        }


        public Task<ObservableCollection<ProductDTO>> MapToDTOList(ObservableCollection<ProductDAO> productDAOs)
        {
            Task.Run<ObservableCollection<ProductDTO>>(() =>
           {
               ObservableCollection<ProductDTO> DTOs = new ObservableCollection<ProductDTO>();
               foreach (var item in productDAOs)
               {
                   DTOs.Add(new ProductDTO
                   {
                       ID = item.ID,
                       Barcode = item.Barcode,
                       Price = item.SellPrice,
                       Name = item.Name
                   });
               }
               return DTOs;
           });
            return null;
        }
    }
}
