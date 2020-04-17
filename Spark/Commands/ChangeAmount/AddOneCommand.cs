using Spark.ViewModel.Windows;

namespace Spark.Commands.ChangeAmount
{
    public class AddOneCommand : ChangeAmountCommandBase
    {
        readonly ChangeAmountViewModel changeAmountVM;
        public AddOneCommand(ChangeAmountViewModel changeAmountVM)
            : base(changeAmountVM)
        {
            this.changeAmountVM = changeAmountVM;
        }

        public override void Execute(object parameter) => changeAmountVM.Count += "1";
    }
}

