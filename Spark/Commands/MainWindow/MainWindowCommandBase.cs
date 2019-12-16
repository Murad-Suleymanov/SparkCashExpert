using Spark.ViewModel.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Commands.MainWindow
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
