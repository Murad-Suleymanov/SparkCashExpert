using Spark.ViewModel.Windows;

namespace Spark.Commands
{
    public class AddEightFPCommand : FindProductCommandBase
    {
        readonly FindProductViewModel findProductVM;
        public AddEightFPCommand(FindProductViewModel findProductVM) : base(findProductVM)
        {
            this.findProductVM = findProductVM;
        }

        public override void Execute(object parameter) => findProductVM.SearchString += "8";
    }
}
