using Spark.ViewModel.Selling;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Spark
{
    /// <summary>
    /// Interaction logic for SellingControl.xaml
    /// </summary>
    public partial class SellingControl : UserControl
    {
        SellingViewModel sellingVM;
        public SellingControl(SellingViewModel sellingVM)
        {
            InitializeComponent();
            this.sellingVM = sellingVM;
            DataContext = this.sellingVM;
        }

        public void Show()
        {
            
        }


    }
}
