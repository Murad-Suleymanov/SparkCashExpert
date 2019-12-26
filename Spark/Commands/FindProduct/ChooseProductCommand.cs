using Spark.Dal.DataAccess;
using Spark.Dal.Domain.Entities;
using Spark.ViewModel.Windows;
using System;

namespace Spark.Commands
{
    public class ChooseProductCommand : FindProductCommandBase
    {
        readonly FindProductViewModel findProductVM;
        readonly MainWindowViewModel mainWindowVM;
        public ChooseProductCommand(FindProductViewModel findProductVM) : base(findProductVM)
        {
            mainWindowVM = findProductVM.MainWindowVM;
        }

        public override void Execute(object parameter)
        {
            UserDAO user = new UserDAO
            {
                ID = 1.ToString(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                UserName = "Murad",
                Name = "Murad",
                Surname = "Suleymanov",
                Patronmyc = "Eldeniz",
                TwoFactoryEnabled = true,
                PasswordHash = 123.ToString(),
                AccesFailedCount = 1,
                CreateDate = new DateTime(1998, 08, 22),
                RegUser = 1.ToString()
            };
            mainWindowVM.DataGridProducts.Add(new ProductDAO { Barcode = "12345", Count = 1, Name = "Kere yagi", SellPrice = 12 });
            SqlInvoiceDAORepository sql = new SqlInvoiceDAORepository(new SqlContext());
            sql.InsertOrUpdate(new InvoiceDAO
            {
                ID = 2,
                InvoiceDate = new DateTime(1998, 08, 22),
                InvoiceNumber = 1,
                InvoiceType = 1,
                IsCanceled = true,
                User = user
            });
        }
    }
}
