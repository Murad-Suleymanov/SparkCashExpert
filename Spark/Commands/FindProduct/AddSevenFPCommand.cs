using Spark.ViewModel.Windows;

namespace Spark.Commands
{
    public class AddSevenFPCommand : FindProductCommandBase
    {
        readonly FindProductViewModel findProductVM;
        public AddSevenFPCommand(FindProductViewModel findProductVM) : base(findProductVM)
        {
            this.findProductVM = findProductVM;
        }

        public override void Execute(object parameter) => findProductVM.SearchString += "7";
    }
}
