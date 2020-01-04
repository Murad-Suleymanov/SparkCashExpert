using Spark.ViewModel.Windows;
using System;
using System.Timers;
using System.Windows;

namespace Spark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        MainWindowViewModel mainWindowVM;
        public MainWindow(MainWindowViewModel mainWindowVM)
        {
            InitializeComponent();
            this.mainWindowVM = mainWindowVM;
            DataContext = mainWindowVM;
            mainWindowVM.Window = this;
            timer.Interval = 1000;
            timer.Elapsed += timerElapse;
            timer.Start();
        }

        public void timerElapse(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                lblDateTime.Content = DateTime.Now.ToString("HH:mm:ss");
                lblDateTimeDay.Content = (DateTime.Now.ToString("dd:MM:yyyy"));
            });
        }

        void ShowView() => ShowDialog();

        void ShowDateTime() => lblDateTime.Content = string.Format("{0}:{1}:{2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        
    }
}
