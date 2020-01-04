using Spark.BusinessLogich.Calculating;
using Spark.Dal.DataAccess;
using Spark.Dal.Domain.Abstract;
using Spark.Model;
using Spark.ViewModel.Windows;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Spark.Commands.RequestAdminC
{
    public class SignInCommand : RequestAdminCommandBase
    {
        readonly IUnitOfWork db;
        readonly RequestAdminViewModel requestAdminVM;
        readonly MainWindowViewModel mainWindowVM;
        public SignInCommand(RequestAdminViewModel requestAdminVM) : base(requestAdminVM)
        {
            this.requestAdminVM = requestAdminVM;
            mainWindowVM = requestAdminVM.DeleteRowVM.MainWindowVM;
            db = new SqlUnifOfWork();
        }


        public override void Execute(object parameter)
        {
            string password = (parameter as PasswordBox)?.Password;
            if (string.IsNullOrWhiteSpace(password)
                || string.IsNullOrWhiteSpace(requestAdminVM.Username))
                requestAdminVM.EmptyErrorVisibility = Visibility.Visible;
            else
            {
                requestAdminVM.CurrentWindow.Close();
                mainWindowVM.InvoiceDetail.IsCanceled = true;
                ObservableCollection<InvoiceDetailDTO> dTOs = new ObservableCollection<InvoiceDetailDTO>();
                foreach (var item in mainWindowVM.DataGridProducts)
                {
                    dTOs.Add(item);
                }
                mainWindowVM.DataGridProducts.Clear();
                mainWindowVM.DataGridProducts = dTOs;
                mainWindowVM.TotalSum = Task.Run<string>(async () =>
                {
                    double d = await Calculate.TotalSum(InvoiceDetailDTO.ToEntities(mainWindowVM.DataGridProducts)
                         .GetAwaiter().GetResult());
                    return d.ToString();
                }).GetAwaiter().GetResult();
            }
        }
    }
}
