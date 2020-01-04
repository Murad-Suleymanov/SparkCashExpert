using Spark.Commands;
using Spark.Commands.CalculateRemainder;
using System;

namespace Spark.ViewModel.Windows
{
    public class CalculateRemainderViewModel : WindowViewModel
    {
        public CalculateRemainderCancelCommand cancelCommand => new CalculateRemainderCancelCommand(this);
        public ConfirmInvoiceCommand confirmInvoiceCommand => new ConfirmInvoiceCommand(this);

        public MainWindowViewModel MainWindowVM { get; set; }

        private string totalSum;

        public string TotalSum
        {
            get => totalSum;
            set
            {
                totalSum = value;
                OnPropertyChanged(nameof(TotalSum));
                OnPropertyChanged(nameof(Remainder));
            }
        }

        private string withCart;

        public string WithCart
        {
            get => withCart;
            set
            {
                withCart = value;
                OnPropertyChanged(nameof(WithCart));
                OnPropertyChanged(nameof(Remainder));
            }
        }


        private string withCash;

        public string WithCash
        {
            get => withCash;
            set
            {
                withCash = value;
                OnPropertyChanged(nameof(WithCash));
                OnPropertyChanged(nameof(Remainder));
            }
        }


        private string remainder;

        public string Remainder
        {
            get => Calculate().ToString();
        }

        public double Calculate()
        {
            double b = -(Convert.ToDouble(TotalSum ?? "0") - (Convert.ToDouble(WithCart ?? "0")
                    + Convert.ToDouble(WithCash)));
            return b;
        }

    }
}
