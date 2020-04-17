using Spark.ViewModel.Windows;

namespace Spark.Commands.ChangeAmount
{
    public class AddFiveCommand:ChangeAmountCommandBase
    {
        readonly ChangeAmountViewModel changeAmountVM;
        public AddFiveCommand(ChangeAmountViewModel changeAmountVM) : base(changeAmountVM)
        {
            this.changeAmountVM = changeAmountVM;
        }


        public override void Execute(object parameter) => changeAmountVM.Count += "5";
    }
}
