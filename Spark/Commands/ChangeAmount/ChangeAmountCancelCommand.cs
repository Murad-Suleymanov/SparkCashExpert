using Spark.ViewModel.Windows;

namespace Spark.Commands
{
    public class ChangeAmountCancelCommand : ChangeAmountCommandBase
    {
        ChangeAmountViewModel changeAmountVM;
        public ChangeAmountCancelCommand(ChangeAmountViewModel changeAmountVM):base(changeAmountVM)
        {
            this.changeAmountVM = changeAmountVM;
        }

        public override void Execute(object parameter)
        {
            changeAmountVM.CurrentWindow.Close();
        }
    }
}
