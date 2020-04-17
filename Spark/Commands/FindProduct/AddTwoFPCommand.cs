using Spark.ViewModel.Windows;

namespace Spark.Commands
{
    public class AddTwoFPCommand : FindProductCommandBase
    {
        readonly FindProductViewModel findProductVM;
        public AddTwoFPCommand(FindProductViewModel findProductVM) : base(findProductVM)
        {
            this.findProductVM = findProductVM;
        }

        public override void Execute(object parameter) => findProductVM.SearchString += "2";
    }
}
