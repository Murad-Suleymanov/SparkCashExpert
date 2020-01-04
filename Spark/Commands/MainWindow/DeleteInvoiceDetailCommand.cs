using Spark.Model;
using Spark.View.DialogBox;
using Spark.ViewModel.Windows;
using System.Collections.ObjectModel;
using System.Windows;

namespace Spark.Commands.MainWindow
{
    public class DeleteInvoiceDetailCommand : MainWindowCommandBase
    {
        readonly MainWindowViewModel mainWindowVM;
        public DeleteInvoiceDetailCommand(MainWindowViewModel mainWindowVM)
            : base(mainWindowVM)
        {
            this.mainWindowVM = mainWindowVM;
        }

        public override void Execute(object parameter)
        {
            if (mainWindowVM.InvoiceDetail != null)
            {
                ForDeleteInvoice deleteRow = new ForDeleteInvoice(new DeleteRowViewModel
                {
                    MainWindowVM=mainWindowVM
                });
                deleteRow.ShowDialog();
            }
        }
    }
}
