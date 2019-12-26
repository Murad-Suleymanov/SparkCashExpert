using Spark.ViewModel.Windows;
using System;

namespace Spark.Commands
{
    public abstract class MainWindowCommandBase:BaseCommand
    {
        protected MainWindowViewModel mainWindowVM;
        public MainWindowCommandBase(MainWindowViewModel mainWindowVM)
        {
            this.mainWindowVM = mainWindowVM;
        }

        public override bool CanExecute(object parameter) => true;
        public override event EventHandler CanExecuteChanged;
    }
}
