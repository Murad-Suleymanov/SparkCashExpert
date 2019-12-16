using Spark.Helper;
using Spark.View;
using Spark.View.DialogBox;
using Spark.ViewModel.Windows;
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
        MainWindowViewModel mainWindowVM;
        public MainWindow(MainWindowViewModel mainWindowVM)
        {
            InitializeComponent();
            this.mainWindowVM = mainWindowVM;
            DataContext = mainWindowVM;
            mainWindowVM.Window = this;
        }

        void ShowView() => ShowDialog();

        void ShowDateTime() => lblDateTime.Content = string.Format("{0}:{1}:{2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ForDeleteRow changeAmount = new ForDeleteRow();
            changeAmount.Show();
        }




        //private Task FakeMethod()
        //{
        //   return Task.Run(() =>
        //    {
        //        this.Dispatcher.Invoke(() =>
        //        {
        //            CallUC.FillUC(grdForUC, new SellingControl());
        //        });
        //    });
        //}


    }
}
