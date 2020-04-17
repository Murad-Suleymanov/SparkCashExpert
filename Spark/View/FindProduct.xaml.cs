using Spark.ViewModel.Windows;
using System.Windows;

namespace Spark.View
{
    /// <summary>
    /// Interaction logic for FindProduct.xaml
    /// </summary>
    public partial class FindProduct : Window
    {
        FindProductViewModel findProductVM;
        public FindProduct(FindProductViewModel findProductVM)
        {
            InitializeComponent();
            this.findProductVM = findProductVM;
            DataContext = this.findProductVM;
            findProductVM.CurrentWindow = this;
        }


    }
}
