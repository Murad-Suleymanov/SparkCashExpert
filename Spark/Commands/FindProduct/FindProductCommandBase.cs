using Spark.ViewModel.Windows;
using System;

namespace Spark.Commands
{
    public abstract class FindProductCommandBase : BaseCommand
    {
        readonly FindProductViewModel findProductVM;
        public FindProductCommandBase(FindProductViewModel findProductVM)
        {
            this.findProductVM = findProductVM;
        }
        public override bool CanExecute(object parameter) => true;
        public override event EventHandler CanExecuteChanged;
    }
}
