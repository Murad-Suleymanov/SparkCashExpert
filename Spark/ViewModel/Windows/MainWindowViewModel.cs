using Spark.Commands.MainWindow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Spark.ViewModel.Windows
{
    public class MainWindowViewModel : WindowViewModel
    {
        public FindProductCommand findProduct => new FindProductCommand(this);
        public SettingCommand settingCommand => new SettingCommand(this);
        System.Timers.Timer timer;
        public string Username { get; set; }
        public Window Window { get; set; }
        public MainWindowViewModel()
        {
            DateTimeChanged();
        }

        private void DateTimeChanged()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000; // 1 second updates
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }


        //private string changeDateTime = string.Format("{0}:{1}:{2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);


        //public string ChangeDateTime
        //{
        //    get => changeDateTime; 
        //    set
        //    {
        //        changeDateTime = value; 
        //        OnPropertyChanged(nameof(ChangeDateTime));
        //    }
        //}

        private string cashierName;

        public string CashierName
        {
            get { return cashierName; }
            set
            {
                cashierName = value;
                OnPropertyChanged(nameof(CashierName));
            }
        }
        public DateTime Now { get; set; }


        private string cashRegister = "Kassa 1";

        public string CashRegister
        {
            get { return cashRegister; }
            set
            {
                cashRegister = value;
                OnPropertyChanged(nameof(CashRegister));
            }
        }

        private string store = "Magaza Ehmedli";

        public string Store
        {
            get { return store; }
            set
            {
                store = value;
                OnPropertyChanged(nameof(store));
            }
        }


        //public event PropertyChangedEventHandler PropertyChanged;


        public void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Now = DateTime.Now;
            //PropertyChanged += new PropertyChangedEventHandler(NowChanged(this, new PropertyChangedEventArgs(nameof(Now)));
        }

        public void NowChanged(object sender, PropertyChangedEventArgs e)
        {
            
        }
    }
}
