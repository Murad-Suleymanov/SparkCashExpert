using Spark.Dal.DataAccess;
using Spark.Dal.Domain.Abstract;
using Spark.Dal.Domain.Entities;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Spark.Model
{
    public class ProductDTO
    {
        readonly static IUnitOfWork db;
        static ProductDTO()
        {
            db = new SqlUnifOfWork();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Count { get; set; }
        public double Amount { get; set; }
        public string Barcode { get; set; }


        public static Task<ProductDTO> ToDTO(ProductDAO source)
        {
            return Task.Run<ProductDTO>(() =>
             {
                 return new ProductDTO
                 {
                     ID = source.ID,
                     Name = source.Name,
                     Price = source.SellPrice,
                     Barcode = source.Barcode
                 };
             });
        }

        public static Task<ProductDAO> ToDAO(ProductDTO source)
        {
            return Task.Run<ProductDAO>(async () =>
             {
                 ProductDAO dAO = await db.ProductDAORepository.GetByID(source.ID);
                 return dAO;
             });
        }

        public static Task<ObservableCollection<ProductDTO>> ToDTOS
            (ObservableCollection<ProductDAO> dAOs)
        {
            return Task.Run<ObservableCollection<ProductDTO>>(() =>
            {
                ObservableCollection<ProductDTO> products = new ObservableCollection<ProductDTO>();
                if (dAOs != null)
                {
                    foreach (var item in dAOs)
                    {
                        products.Add(new ProductDTO
                        {
                            ID = item.ID,
                            Name = item.Name,
                            Price = item.SellPrice,
                            Barcode = item.Barcode
                        });
                    }
                }
                return products;
            });
        }
    }
}
