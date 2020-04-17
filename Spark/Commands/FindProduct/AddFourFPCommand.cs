using Spark.ViewModel.Windows;

namespace Spark.Commands
{
    public class AddFourFPCommand : FindProductCommandBase
    {
        readonly FindProductViewModel findProductVM;
        public AddFourFPCommand(FindProductViewModel findProductVM) : base(findProductVM)
        {
            this.findProductVM = findProductVM;
        }

        public override void Execute(object parameter) => findProductVM.SearchString += "4";
    }
}
