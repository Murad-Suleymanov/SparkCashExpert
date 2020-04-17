using Spark.ViewModel.Windows;

namespace Spark.Commands.ChangeAmount
{
    public class AddEightCommand : ChangeAmountCommandBase
    {
        readonly ChangeAmountViewModel changeAmountVM;
        public AddEightCommand(ChangeAmountViewModel changeAmountVM) : base(changeAmountVM)
        {
            this.changeAmountVM = changeAmountVM;
        }


        public override void Execute(object parameter) => changeAmountVM.Count += "8";
    }
}
