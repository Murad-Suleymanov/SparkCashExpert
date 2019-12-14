using Spark.Helper;
using System;
using System.Collections.Generic;
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
using System.Windows.Threading;
using static Spark.Helper.CallUC;

namespace Spark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FakeMethod();
        }

        private  void BtnNewSale_Click(object sender, RoutedEventArgs e)
        {
            // CallUC.FillUC(grdForUC, new Satis());
            CallUC.FillUC(grdForUC, new Satis());
        }

        private Task FakeMethod()
        {
           return Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    CallUC.FillUC(grdForUC, new Satis());
                });
            });
        }

        public void FillUC1(Grid grd, UserControl uc)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (grd.Children.Count > 0)
                {
                    grd.Children.Clear();
                    grd.Children.Add(uc);
                }
                else
                    grd.Children.Add(uc);
            });
        }
    }
}
