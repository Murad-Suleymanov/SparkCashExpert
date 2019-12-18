using Spark.ViewModel.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Commands.FindProduct
{
    public class CancelCommand : FindProductCommandBase
    {
        FindProductViewModel findProductVM;
        public CancelCommand(FindProductViewModel findProductVM) : base(findProductVM)
        {
            this.findProductVM = findProductVM;
        }

        public override void Execute(object parameter) => findProductVM.CurrentWindow.Close();
    }
}
