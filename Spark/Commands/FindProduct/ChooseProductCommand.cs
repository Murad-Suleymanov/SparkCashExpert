using Spark.BusinessLogich.Calculating;
using Spark.Model;
using Spark.ViewModel.Windows;
using System.Threading.Tasks;

namespace Spark.Commands
{
    public class ChooseProductCommand : FindProductCommandBase
    {
        readonly FindProductViewModel findProductVM;
        readonly MainWindowViewModel mainWindowVM;
        public ChooseProductCommand(FindProductViewModel findProductVM) : base(findProductVM)
        {
            mainWindowVM = findProductVM.MainWindowVM;
            this.findProductVM = findProductVM;
        }

        public override void Execute(object parameter)
        {
            if (findProductVM.SelectedItem != null)
            {
                mainWindowVM.DataGridProducts.Add(new InvoiceDetailDTO
                {
                    Product = findProductVM.SelectedItem,
                    CurrentPrice = findProductVM.SelectedItem.Price,
                    Count = 1
                });

                mainWindowVM.TotalSum = Task.Run<string>(async () =>
                {
                    double d = await Calculate.TotalSum(InvoiceDetailDTO.ToEntities(mainWindowVM.DataGridProducts)
                         .GetAwaiter().GetResult());
                    return d.ToString();
                }).GetAwaiter().GetResult();

                findProductVM.CurrentWindow.Close();
            }
        }
    }
}
