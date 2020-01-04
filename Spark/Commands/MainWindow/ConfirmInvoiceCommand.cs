using Spark.ViewModel.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Commands.MainWindow
{
    public class ConfirmInvoiceCommand : MainWindowCommandBase
    {
        readonly MainWindowViewModel mainWindowVM;
        public ConfirmInvoiceCommand(MainWindowViewModel mainWindowVM):base(mainWindowVM)
        {
            this.mainWindowVM = mainWindowVM;
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
