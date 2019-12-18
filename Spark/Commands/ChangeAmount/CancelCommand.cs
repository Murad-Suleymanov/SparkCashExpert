using Spark.ViewModel.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Commands.ChangeAmount
{
    public class CancelCommand : ChangeAmountCommandBase
    {
        ChangeAmountViewModel changeAmountVM;
        public CancelCommand(ChangeAmountViewModel changeAmountVM):base(changeAmountVM)
        {
            this.changeAmountVM = changeAmountVM;
        }

        public override void Execute(object parameter)
        {
            changeAmountVM.CurrentWindow.Close();
        }
    }
}
