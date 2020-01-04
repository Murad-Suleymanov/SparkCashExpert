using Spark.ViewModel.Windows;
using System.Windows;

namespace Spark.View
{
    /// <summary>
    /// Interaction logic for ChangeAmount.xaml
    /// </summary>
    public partial class ChangeAmount : Window
    {
        readonly ChangeAmountViewModel changeAmountVM;
        public ChangeAmount(ChangeAmountViewModel changeAmountVM)
        {
            InitializeComponent();
            this.changeAmountVM =changeAmountVM;
            DataContext = this.changeAmountVM;
            changeAmountVM.CurrentWindow = this;
        }
    }
}
