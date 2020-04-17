using Spark.ViewModel.Windows;

namespace Spark.Commands.ChangeAmount
{
    public class AddFourCommand:ChangeAmountCommandBase
    {
        readonly ChangeAmountViewModel changeAmountVM;
        public AddFourCommand(ChangeAmountViewModel changeAmountVM) : base(changeAmountVM)
        {
            this.changeAmountVM = changeAmountVM;
        }


        public override void Execute(object parameter) => changeAmountVM.Count += "4";
    }
}
