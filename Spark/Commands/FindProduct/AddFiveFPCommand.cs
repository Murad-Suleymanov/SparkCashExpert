using Spark.ViewModel.Windows;

namespace Spark.Commands
{
    public class AddFiveFPCommand : FindProductCommandBase
    {
        readonly FindProductViewModel findProductVM;
        public AddFiveFPCommand(FindProductViewModel findProductVM) : base(findProductVM)
        {
            this.findProductVM = findProductVM;
        }

        public override void Execute(object parameter) => findProductVM.SearchString += "5";
    }
}
