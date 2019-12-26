using Spark.ViewModel.Windows;

namespace Spark.Commands
{
    public class CalculateRemainderCancelCommand : CalculateRemainderCommandBase
    {
        CalculateRemainderViewModel _calculateRemainderVM;
        public CalculateRemainderCancelCommand(CalculateRemainderViewModel calculateRemainderVM) : base(calculateRemainderVM)
        {
            _calculateRemainderVM = calculateRemainderVM;
        }


        public override void Execute(object parameter)
        {
            _calculateRemainderVM.CurrentWindow.Close();
        }
    }
}
