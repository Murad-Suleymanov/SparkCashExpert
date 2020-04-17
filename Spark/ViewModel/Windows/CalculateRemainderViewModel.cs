using Spark.Commands;
using Spark.Commands.CalculateRemainder;
using System;
using System.Windows;

namespace Spark.ViewModel.Windows
{
    public class CalculateRemainderViewModel : WindowViewModel
    {
        public CalculateRemainderCancelCommand cancelCommand => new CalculateRemainderCancelCommand(this);
        public ConfirmInvoiceCommand confirmInvoiceCommand => new ConfirmInvoiceCommand(this);

        //0-9 number and helper buttons
        #region
        public AddOneCRCommand addOneCRCommand => new AddOneCRCommand(this);
        #endregion

        public MainWindowViewModel MainWindowVM { get; set; }


        public bool IsFocusedTxt1 { get; set; }

        public bool IsFocusedTxt2 { get; set; }


        private bool isFocusedWithCashTxt = true;

        private string focusedElementName;

        public string FocusedElementName
        {
            get => focusedElementName;
            set
            {
                focusedElementName = value;
                OnPropertyChanged(nameof(FocusedElementName));
            }
        }



        public bool IsFocusedWithCashTxt
        {
            get => isFocusedWithCashTxt;
            set
            {
                isFocusedWithCashTxt = value;
                OnPropertyChanged(nameof(IsFocusedWithCashTxt));
            }
        }


        private bool isFocusedWithCartTxt;

        public bool IsFocusedWithCartTxt
        {
            get => isFocusedWithCartTxt;
            set
            {
                isFocusedWithCartTxt = value;
                OnPropertyChanged(nameof(IsFocusedWithCartTxt));
            }
        }


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
                IsFocusedWithCashTxt = false;
                IsFocusedWithCartTxt = true;
                OnPropertyChanged(nameof(WithCart));
                OnPropertyChanged(nameof(Remainder));
                OnPropertyChanged(nameof(IsFocusedWithCartTxt));
                OnPropertyChanged(nameof(IsFocusedWithCashTxt));
            }
        }


        private string withCash;

        public string WithCash
        {
            get => withCash;
            set
            {
                withCash = value;
                IsFocusedWithCashTxt = true;
                IsFocusedWithCartTxt = false;
                OnPropertyChanged(nameof(WithCash));
                OnPropertyChanged(nameof(Remainder));
                OnPropertyChanged(nameof(IsFocusedWithCashTxt));
                OnPropertyChanged(nameof(IsFocusedWithCartTxt));
            }
        }


        private string remainder;

        public string Remainder
        {
            get => Calculate().ToString();
        }

        public double Calculate()
        {
            try
            {
                double b = -(Convert.ToDouble(TotalSum ?? "0") - (Convert.ToDouble(WithCart ?? "0")
                    + Convert.ToDouble(WithCash)));

                return b;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Daxil etdiyiniz dəyər formata uyğun deyil.");
                return -Convert.ToDouble(TotalSum);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
