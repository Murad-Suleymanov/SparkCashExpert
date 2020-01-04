using Spark.Commands;
using Spark.Commands.MainWindow;
using Spark.Model;
using Spark.Models.Entities;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Spark.ViewModel.Windows
{
    public class MainWindowViewModel : WindowViewModel
    {
        public FindProductCommand findProduct => new FindProductCommand(this);
        public SettingCommand settingCommand => new SettingCommand(this);
        public ChangeAmountCommand amountCommand => new ChangeAmountCommand(this);
        public CalculateRemainderCommand remainderCommand => new CalculateRemainderCommand(this);
        public InsertInvoiceCommand insertInvoiceCommand => new InsertInvoiceCommand(this);
        public DeleteInvoiceDetailCommand deleteDetailCommand => new DeleteInvoiceDetailCommand(this);
        public InvoiceDetailDTO InvoiceDetail { get; set; }
        public ChangeAmountViewModel ChangeAmountVM { get; set; }
        public UserDTO User { get; set; }
        public Window Window { get; set; }
        public MainWindowViewModel() { }


        private string totalSum = "0";

        public string TotalSum
        {
            get => totalSum;
            set
            {
                totalSum = value;
                OnPropertyChanged(nameof(TotalSum));
            }
        }

        private string giftSum="0";

        public string GiftSum
        {
            get { return giftSum; }
            set
            {
                giftSum = value;
                OnPropertyChanged(nameof(GiftSum));
            }
        }
        

        ObservableCollection<InvoiceDetailDTO> dataGridProducts = new ObservableCollection<InvoiceDetailDTO>();

        public ObservableCollection<InvoiceDetailDTO> DataGridProducts
        {
            get => dataGridProducts;
            set
            {
                dataGridProducts = value;
                OnPropertyChanged(nameof(DataGridProducts));
            }
        }

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

    }
}
