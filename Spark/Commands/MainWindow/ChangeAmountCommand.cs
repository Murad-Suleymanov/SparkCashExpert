using Spark.Model;
using Spark.ViewModel.Windows;
using System;
using System.Collections.ObjectModel;

namespace Spark.Commands
{
    public class ChangeAmountCommand : MainWindowCommandBase
    {
        readonly MainWindowViewModel mainWindowVM;
        readonly ChangeAmountViewModel changeAmountVM;
        public ChangeAmountCommand(MainWindowViewModel mainWindowVM) : base(mainWindowVM)
        {
            this.mainWindowVM = mainWindowVM;
            this.changeAmountVM = mainWindowVM.ChangeAmountVM; ;
        }

        public override void Execute(object parameter)
        {
            if (mainWindowVM.InvoiceDetail != null)
            {
                View.ChangeAmount changeAmount = new View.ChangeAmount(new ChangeAmountViewModel
                {
                    MainVindowVM = mainWindowVM
                });
                changeAmount.ShowDialog();
            }
        }
    }
}
