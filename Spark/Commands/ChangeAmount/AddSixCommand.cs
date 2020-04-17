using Spark.ViewModel.Windows;

namespace Spark.Commands.ChangeAmount
{
    public class AddSixCommand : ChangeAmountCommandBase
    {
        readonly ChangeAmountViewModel changeAmountVM;
        public AddSixCommand(ChangeAmountViewModel changeAmountVM) : base(changeAmountVM)
        {
            this.changeAmountVM = changeAmountVM;
        }


        public override void Execute(object parameter) => changeAmountVM.Count += "6";
    }
}
