using Spark.BusinessLogich.Calculating;
using Spark.Model;
using Spark.ViewModel.Windows;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Spark.Commands.ChangeAmount
{
    public class ChooseCountCommand : ChangeAmountCommandBase
    {
        readonly ChangeAmountViewModel changeAmountVM;
        readonly MainWindowViewModel mainWindowVM;
        public ChooseCountCommand(ChangeAmountViewModel changeAmountVM)
            : base(changeAmountVM)
        {
            this.changeAmountVM = changeAmountVM;
            this.mainWindowVM = changeAmountVM.MainVindowVM;
        }

        public override void Execute(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(changeAmountVM.Count))
            {
                mainWindowVM.InvoiceDetail.Count = Convert.ToDouble(changeAmountVM.Count);
                ObservableCollection<InvoiceDetailDTO> dTOs = new ObservableCollection<InvoiceDetailDTO>();
                foreach (var item in mainWindowVM.DataGridProducts)
                {
                    dTOs.Add(item);
                }
                mainWindowVM.DataGridProducts.Clear();
                mainWindowVM.DataGridProducts = dTOs;
                mainWindowVM.TotalSum = Task.Run<string>(async () =>
                {
                    double d = await Calculate.TotalSum(InvoiceDetailDTO.ToEntities(mainWindowVM.DataGridProducts)
                         .GetAwaiter().GetResult());
                    return d.ToString();
                }).GetAwaiter().GetResult();
            }
            changeAmountVM.CurrentWindow.Close();
        }
    }
}
