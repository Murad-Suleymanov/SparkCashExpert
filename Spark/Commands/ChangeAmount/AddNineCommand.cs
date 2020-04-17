using Spark.ViewModel.Windows;

namespace Spark.Commands.ChangeAmount
{
    public class AddNineCommand:ChangeAmountCommandBase
    {
        readonly ChangeAmountViewModel changeAmountVM;
        public AddNineCommand(ChangeAmountViewModel changeAmountVM) : base(changeAmountVM)
        {
            this.changeAmountVM = changeAmountVM;
        }


        public override void Execute(object parameter) => changeAmountVM.Count += "9";
    }
}
