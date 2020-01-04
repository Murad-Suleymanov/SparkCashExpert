using Spark.Dal.DataAccess;
using Spark.Dal.Domain.Abstract;
using Spark.Login.ViewModel;
using Spark.ViewModel.Windows;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Spark.Login.Commands.Login
{
    public class SignInCommand : LoginCommandBase
    {
        readonly MainWindowViewModel MainWindowVM;
        readonly IUnitOfWork db;
        public SignInCommand(LoginViewModel LoginVM) : base(LoginVM)
        {
            db = new SqlUnifOfWork();
        }

        public override void Execute(object parameter)
        {
            string password = (parameter as PasswordBox)?.Password;
            if (string.IsNullOrEmpty(password))
                LoginVM.ErrorVisibility = Visibility.Visible;
            if (string.IsNullOrEmpty(LoginVM.User.UserName))
                LoginVM.ErrorVisibility = Visibility.Visible;
            else
            {
                Task.Run(() =>
                    {
                        Thread.Sleep(1000);
                        Application.Current.Dispatcher?.Invoke(() => { LoginVM.Window.Close(); });
                    });

                new Spark.MainWindow(new MainWindowViewModel
                {
                    CashierName = LoginVM.User.UserName
                }).ShowDialog();
            }
        }
    }
}
