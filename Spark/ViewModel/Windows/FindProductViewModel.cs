using Spark.Commands;

namespace Spark.ViewModel.Windows
{
    public class FindProductViewModel : WindowViewModel
    {
        public FindProductCancelCommand cancelCommand => new FindProductCancelCommand(this);
        public ChooseProductCommand chooseProductCommand => new ChooseProductCommand(this);
        public MainWindowViewModel MainWindowVM { get; set; }

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
