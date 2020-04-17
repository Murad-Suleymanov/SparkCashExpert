using Spark.ViewModel.Windows;

namespace Spark.Commands.ChangeAmount
{
    public class AddSevenCommand:ChangeAmountCommandBase
    {
        readonly ChangeAmountViewModel changeAmountVM;
        public AddSevenCommand(ChangeAmountViewModel changeAmountVM) : base(changeAmountVM)
        {
            this.changeAmountVM = changeAmountVM;
        }


        public override void Execute(object parameter) => changeAmountVM.Count += "7";
    }
}
