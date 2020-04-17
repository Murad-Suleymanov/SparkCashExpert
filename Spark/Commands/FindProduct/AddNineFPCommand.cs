using Spark.ViewModel.Windows;

namespace Spark.Commands
{
    public class AddNineFPCommand : FindProductCommandBase
    {
        readonly FindProductViewModel findProductVM;
        public AddNineFPCommand(FindProductViewModel findProductVM) : base(findProductVM)
        {
            this.findProductVM = findProductVM;
        }

        public override void Execute(object parameter) => findProductVM.SearchString += "9";
    }
}
