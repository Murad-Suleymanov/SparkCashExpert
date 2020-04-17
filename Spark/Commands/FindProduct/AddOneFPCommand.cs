using Spark.ViewModel.Windows;

namespace Spark.Commands
{
    public class AddOneFPCommand : FindProductCommandBase
    {
        readonly FindProductViewModel findProductVM;
        public AddOneFPCommand(FindProductViewModel findProductVM) : base(findProductVM)
        {
            this.findProductVM = findProductVM;
        }

        public override void Execute(object parameter) => findProductVM.SearchString += "1";
    }
}
