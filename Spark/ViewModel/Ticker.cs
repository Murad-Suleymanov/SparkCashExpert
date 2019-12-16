using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Spark.ViewModel
{
    public class Ticker : INotifyPropertyChanged
    {

        public Ticker()
        {
            Timer timer = new Timer();
            timer.Interval = 1000; // 1 second updates
            timer.Elapsed += OnPropertyChanged;
            timer.Start();
        }

        public DateTime Now
        {
            get { return DateTime.Now; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(object sender,ElapsedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Now)));
        }
    }
}
