using Spark.ViewModel.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Commands.MainWindow
{
    public class ChangeAmountCommand : MainWindowCommandBase
    {
        MainWindowViewModel mainWindowVM;
        public ChangeAmountCommand(MainWindowViewModel mainWindowVM):base(mainWindowVM)
        {
        }

        public override void Execute(object parameter)
        {
            View.ChangeAmount changeAmount = new View.ChangeAmount();
            changeAmount.ShowDialog();
        }
    }
}
