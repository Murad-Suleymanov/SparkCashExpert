using Spark.ViewModel.Windows;

namespace Spark.Commands
{
    public class AddSixFPCommand : FindProductCommandBase
    {
        readonly FindProductViewModel findProductVM;
        public AddSixFPCommand(FindProductViewModel findProductVM) : base(findProductVM)
        {
            this.findProductVM = findProductVM;
        }

        public override void Execute(object parameter) => findProductVM.SearchString += "6";
    }
}
