using Spark.ViewModel.Windows;

namespace Spark.Commands
{
    public class DeleteNumberFPCommand : FindProductCommandBase
    {
        readonly FindProductViewModel findProductVM;
        public DeleteNumberFPCommand(FindProductViewModel findProductVM) : base(findProductVM)
        {
            this.findProductVM = findProductVM;
        }

        public override void Execute(object parameter)
        {
            if (findProductVM.SearchString.Length > 0)
            {
                findProductVM.SearchString = findProductVM.SearchString
                    .Substring(0, findProductVM.SearchString.Length - 1);
            }
            else
                findProductVM.SearchString = "";
        }
    }
}
