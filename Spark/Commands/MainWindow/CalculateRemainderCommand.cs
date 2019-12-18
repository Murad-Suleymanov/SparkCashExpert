using Spark.ViewModel.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Commands.MainWindow
{
    public class CalculateRemainderCommand : MainWindowCommandBase
    {
        MainWindowViewModel mainWindowVM;
        public CalculateRemainderCommand(MainWindowViewModel mainWindowVM) : base(mainWindowVM)
        {
        }

        public override void Execute(object parameter)
        {
            View.CalculateRemainder calculateRemainder = new View.CalculateRemainder();
            calculateRemainder.ShowDialog();
        }
    }
}
