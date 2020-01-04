using Spark.ViewModel.Windows;
using System.Windows;

namespace Spark.View.DialogBox
{
    /// <summary>
    /// Interaction logic for ForDeleteInvoice.xaml
    /// </summary>
    public partial class ForDeleteInvoice : Window
    {
        readonly DeleteRowViewModel deleteRowVM;
        public ForDeleteInvoice(DeleteRowViewModel deleteRowVM)
        {
            InitializeComponent();
            this.deleteRowVM = deleteRowVM;
            DataContext = deleteRowVM;
            deleteRowVM.CurrentWindow = this;
        }
    }
}
