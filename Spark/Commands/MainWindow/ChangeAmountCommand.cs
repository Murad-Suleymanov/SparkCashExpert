using Spark.ViewModel.Windows;

namespace Spark.Commands
{
    public class ChangeAmountCommand : MainWindowCommandBase
    {
        MainWindowViewModel mainWindowVM;
        public ChangeAmountCommand(MainWindowViewModel mainWindowVM):base(mainWindowVM)
        {
        }

        public override void Execute(object parameter)
        {
            View.ChangeAmount changeAmount = new View.ChangeAmount();
            changeAmount.ShowDialog();
        }
    }
}
