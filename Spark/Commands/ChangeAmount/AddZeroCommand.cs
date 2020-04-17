using Spark.ViewModel.Windows;
using System.Linq;

namespace Spark.Commands.ChangeAmount
{
    public class AddZeroCommand:ChangeAmountCommandBase
    {
        readonly ChangeAmountViewModel changeAmountVM;
        public AddZeroCommand(ChangeAmountViewModel changeAmountVM) : base(changeAmountVM)
        {
            this.changeAmountVM = changeAmountVM;
        }


        public override void Execute(object parameter) => changeAmountVM.Count += "0";
    }
}
