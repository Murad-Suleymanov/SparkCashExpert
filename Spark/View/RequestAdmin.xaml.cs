using Spark.ViewModel.Windows;
using System.Windows;

namespace Spark.View
{
    /// <summary>
    /// Interaction logic for RequestAdmin.xaml
    /// </summary>
    public partial class RequestAdmin : Window
    {
        readonly RequestAdminViewModel requestAdminVM;
        public RequestAdmin(RequestAdminViewModel requestAdminVM)
        {
            InitializeComponent();
            this.requestAdminVM = requestAdminVM;
            DataContext = requestAdminVM;
            requestAdminVM.CurrentWindow = this;
        }
    }
}
