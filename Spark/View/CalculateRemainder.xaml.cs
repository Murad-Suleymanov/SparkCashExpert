using Spark.ViewModel.Windows;
using System.Windows;

namespace Spark.View
{
    /// <summary>
    /// Interaction logic for CalculateRemainder.xaml
    /// </summary>
    public partial class CalculateRemainder : Window
    {
        readonly CalculateRemainderViewModel calculateRemainderVM;
        public CalculateRemainder(CalculateRemainderViewModel calculateRemainderVM)
        {
            InitializeComponent();
            this.calculateRemainderVM = calculateRemainderVM;
            DataContext = calculateRemainderVM;
            calculateRemainderVM.CurrentWindow = this;
        }
    }
}
