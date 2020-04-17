using Spark.ViewModel.Windows;
using Spark.View;

namespace Spark.Commands
{
    public class FindProductCommand : MainWindowCommandBase
    {
        MainWindowViewModel mainWindowVM;
        public FindProductCommand(MainWindowViewModel mainWindowVM) : base(mainWindowVM)
        {
            this.mainWindowVM = mainWindowVM;
        }

        public override void Execute(object parameter)
        {
            Spark.View.FindProduct findProduct = new Spark.View.FindProduct
                (new FindProductViewModel { MainWindowVM = mainWindowVM });
            findProduct.Show();
        }
    }
}
