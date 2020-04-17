using Spark.ViewModel.Windows;

namespace Spark.Commands.ChangeAmount
{
    public class AddPointCommand : ChangeAmountCommandBase
    {
        readonly ChangeAmountViewModel changeAmountVM;
        public AddPointCommand(ChangeAmountViewModel changeAmountVM) : base(changeAmountVM)
        {
            this.changeAmountVM = changeAmountVM;
        }


        public override void Execute(object parameter) => changeAmountVM.Count += ".";
    }
}
