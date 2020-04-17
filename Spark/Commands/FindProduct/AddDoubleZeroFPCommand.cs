using Spark.ViewModel.Windows;

namespace Spark.Commands
{
    public class AddDoubleZeroFPCommand : FindProductCommandBase
    {
        readonly FindProductViewModel findProductVM;
        public AddDoubleZeroFPCommand(FindProductViewModel findProductVM) : base(findProductVM)
        {
            this.findProductVM = findProductVM;
        }

        public override void Execute(object parameter) => findProductVM.SearchString += "00";
    }
}
