using Spark.BusinessLogich.Calculating;
using Spark.Model;
using Spark.ViewModel.Windows;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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

        public async override void Execute(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(changeAmountVM.Count))
            {
                try
                {
                    mainWindowVM.InvoiceDetail.Count = Convert.ToDouble(changeAmountVM.Count);
                    ObservableCollection<InvoiceDetailDTO> dTOs = new ObservableCollection<InvoiceDetailDTO>();
                    foreach (var item in mainWindowVM.DataGridProducts)
                    {
                        dTOs.Add(item);
                    }
                    mainWindowVM.DataGridProducts.Clear();
                    mainWindowVM.DataGridProducts = dTOs;
                    mainWindowVM.TotalSum = await Task.Run<string>(async () =>
                    {
                        double d = await Calculate.TotalSum(InvoiceDetailDTO.ToEntities(mainWindowVM.DataGridProducts)
                             .GetAwaiter().GetResult());
                        return d.ToString();
                    });
                    changeAmountVM.CurrentWindow.Close();
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Zəhmət olmasa yazdığınız miqdarı yoxlayın","Yazılış səhvi",MessageBoxButton.OK,MessageBoxImage.Error);
                    changeAmountVM.Count = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Səhv baş verdi, zəhmət olmasa yenidən yoxlayın");
                }
            }
        }
    }
}
