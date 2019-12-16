using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Spark.ViewModel.Windows
{
    public class FindProductViewModel:WindowViewModel
    {
        private string barcode;

        public string Barcode
        {
            get { return barcode; }
            set
            {
                barcode = value;
                OnPropertyChanged(nameof(Barcode));
            }
        }

    }
}
