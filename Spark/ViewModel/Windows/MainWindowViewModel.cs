using Spark.Commands;
using Spark.Dal.Domain.Entities;
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
        public string Username { get; set; }
        public Window Window { get; set; }
        public MainWindowViewModel()
        {
        }

        ObservableCollection<ProductDAO> dataGridProducts = new ObservableCollection<ProductDAO>();

        public ObservableCollection<ProductDAO> DataGridProducts
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

    }
}
