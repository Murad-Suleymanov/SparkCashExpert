using Spark.Model;
using Spark.View;
using Spark.ViewModel.Windows;
using System;
using System.Collections.ObjectModel;

namespace Spark.Commands.DeleteRow
{
    public class ResponseRowYesCommand : DeleteRowCommandBase
    {
        readonly DeleteRowViewModel deleteRowVM;
        readonly MainWindowViewModel mainWindowVM;
        public ResponseRowYesCommand(DeleteRowViewModel deleteRowVM)
            : base(deleteRowVM)
        {
            this.deleteRowVM = deleteRowVM;
            this.mainWindowVM = deleteRowVM.MainWindowVM;
        }

        public override void Execute(object parameter)
        {
            deleteRowVM.IsAccepted = true;
            deleteRowVM.CurrentWindow.Close();
            if (mainWindowVM.InvoiceDetail != null)
            {
                RequestAdmin requestAdmin = new RequestAdmin(new RequestAdminViewModel
                {
                    DeleteRowVM = deleteRowVM
                });
                requestAdmin.ShowDialog();
            }
        }
    }
}
