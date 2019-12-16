using Spark.ViewModel.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Spark.ViewModel
{
    public abstract class UCViewModel:BaseViewModel
    {
        public MainWindowViewModel MainWindowVM { get; set; }
        public abstract string Header { get;}
        public abstract UserControl UserControl { get; set; }
    }
}
