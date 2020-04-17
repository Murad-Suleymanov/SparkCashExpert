using Spark.ViewModel.Windows;

namespace Spark.Commands
{
    public class AddThreeFPCommand : FindProductCommandBase
    {
        readonly FindProductViewModel findProductVM;
        public AddThreeFPCommand(FindProductViewModel findProductVM) : base(findProductVM)
        {
            this.findProductVM = findProductVM;
        }

        public override void Execute(object parameter) => findProductVM.SearchString += "3";
    }
}
