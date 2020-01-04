using Spark.BusinessLogich.Calculating;
using Spark.Model;
using Spark.ViewModel.Windows;
using System.Threading.Tasks;

namespace Spark.Commands
{
    public class CalculateRemainderCommand : MainWindowCommandBase
    {
        readonly MainWindowViewModel mainWindowVM;
        public CalculateRemainderCommand(MainWindowViewModel mainWindowVM) : base(mainWindowVM)
        {
            this.mainWindowVM = mainWindowVM;
        }

        public override void Execute(object parameter)
        {
            View.CalculateRemainder calculateRemainder = new View.CalculateRemainder(
                new CalculateRemainderViewModel
                {
                    TotalSum = mainWindowVM.TotalSum,
                    MainWindowVM = mainWindowVM
                });
            calculateRemainder.ShowDialog();
        }
    }
}
