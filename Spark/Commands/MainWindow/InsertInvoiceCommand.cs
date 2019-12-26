using Spark.Dal.Domain.Entities;
using Spark.ViewModel.Windows;

namespace Spark.Commands
{
    public class InsertInvoiceCommand : MainWindowCommandBase
    {
        public InsertInvoiceCommand(MainWindowViewModel mainWindowVM) : base(mainWindowVM)
        {
        }

        public override void Execute(object parameter)
        {
           // eF.ProductRepository.AddOrUpdate(new ProductDAO { Barcode = "1234567", Count = 1, Name = "Duru yag", ProductType = 1, ProductType1 = new ProductType { ID = 1 } });
        }
    }
}
