using Spark.ViewModel.Windows;

namespace Spark.Commands.ChangeAmount
{
    public class AddThreeCommand : ChangeAmountCommandBase
    {
        readonly ChangeAmountViewModel changeAmountVM;
        public AddThreeCommand(ChangeAmountViewModel changeAmountVM):base(changeAmountVM)
        {
            this.changeAmountVM = changeAmountVM;
        }


        public override void Execute(object parameter) => changeAmountVM.Count += "3";
    }
}
