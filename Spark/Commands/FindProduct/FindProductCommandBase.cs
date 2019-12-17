using Spark.ViewModel.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Commands.FindProduct
{
    public abstract class FindProductCommandBase : BaseCommand
    {
        FindProductViewModel findProductVM;
        public FindProductCommandBase(FindProductViewModel findProductVM)
        {
            this.findProductVM = findProductVM;
        }
        public override bool CanExecute(object parameter) => true;
        public override event EventHandler CanExecuteChanged;
    }
}
