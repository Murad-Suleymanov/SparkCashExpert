using Spark.ViewModel.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Commands.MainWindow
{
    public class SettingCommand : MainWindowCommandBase
    {
        public SettingCommand(MainWindowViewModel mainWindowVM):base(mainWindowVM)
        {
        }

        public override void Execute(object parameter)
        {
            mainWindowVM.CurrentWindow.Close();
        }
    }
}
