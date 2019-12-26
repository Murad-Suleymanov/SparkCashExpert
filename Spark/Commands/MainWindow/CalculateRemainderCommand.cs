using Spark.ViewModel.Windows;

namespace Spark.Commands
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
