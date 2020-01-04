using Spark.ViewModel.Windows;

namespace Spark.Commands
{
    public class FindProductCancelCommand : FindProductCommandBase
    {
        readonly FindProductViewModel findProductVM;
        public FindProductCancelCommand(FindProductViewModel findProductVM) : base(findProductVM)
        {
            this.findProductVM = findProductVM;
        }

        public override void Execute(object parameter) => findProductVM.CurrentWindow.Close();
    }
}
