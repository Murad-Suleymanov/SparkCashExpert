
using Spark.BusinessLogich.Report;
using Spark.Dal.DataAccess;
using Spark.Dal.Domain.Abstract;
using Spark.Dal.Domain.Entities;
using Spark.Model;
using Spark.Report;
using Spark.ViewModel.Windows;
using System;
using System.Windows;

namespace Spark.Commands.CalculateRemainder
{
    public class ConfirmInvoiceCommand : CalculateRemainderCommandBase
    {
        readonly ITransaction transaction;
        readonly CalculateRemainderViewModel calculateRemainderVM;
        readonly MainWindowViewModel mainWindowVM;
        public ConfirmInvoiceCommand(CalculateRemainderViewModel calculateRemainderVM)
            : base(calculateRemainderVM)
        {
            this.calculateRemainderVM = calculateRemainderVM;
            mainWindowVM = calculateRemainderVM.MainWindowVM;
            transaction = new SqlDbTransaction();
        }

        public async override void Execute(object parameter)
        {
            if (Convert.ToDouble(calculateRemainderVM.Remainder) >= 0)
            {
                bool IsSent = await transaction.BeginTransactionAsync(new InvoiceDAO
                {
                    InvoiceDate = DateTime.Now,
                    InvoiceNumber = 1,
                    InvoiceType = 1,
                    IsCanceled = false,
                    User = new UserDAO
                    {
                        ID = 1.ToString()
                    }
                }, InvoiceDetailDTO.ToDAOS(mainWindowVM.DataGridProducts).GetAwaiter().GetResult());

                if (IsSent)
                    MessageBox.Show("Ugurlu");
                Sender.InvoiceDetails(await InvoiceDetailDTO.ToEntities(mainWindowVM.DataGridProducts),mainWindowVM.CashierName);
                InvoiceDetail.PrintReport();
            }
        }
    }
}
