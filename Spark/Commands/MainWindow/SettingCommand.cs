using Spark.ViewModel.Windows;

namespace Spark.Commands
{
    public class SettingCommand : MainWindowCommandBase
    {
        public SettingCommand(MainWindowViewModel mainWindowVM):base(mainWindowVM)
        {
        }

        public override void Execute(object parameter)
        {
            mainWindowVM.Window.Close();
        }
    }
}
