using Spark.ViewModel.Windows;

namespace Spark.Commands
{
    public class AddZeroFPCommand : FindProductCommandBase
    {
        readonly FindProductViewModel findProductVM;
        public AddZeroFPCommand(FindProductViewModel findProductVM) : base(findProductVM)
        {
            this.findProductVM = findProductVM;
        }

        public override void Execute(object parameter) => findProductVM.SearchString += "0";
    }
}
