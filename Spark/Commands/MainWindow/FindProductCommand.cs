using Spark.ViewModel.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Commands.MainWindow
{
    public class FindProductCommand : MainWindowCommandBase
    {
        MainWindowViewModel mainWindowVM;
        public FindProductCommand(MainWindowViewModel mainWindowVM) :base(mainWindowVM)
        {
        }

        public override void Execute(object parameter)
        {
            View.FindProduct findProduct = new View.FindProduct();
            findProduct.Show();
        }
    }
}
