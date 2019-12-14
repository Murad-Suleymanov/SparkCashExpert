using Spark.Login.ViewModel;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Spark.Login.Commands.Login
{
    public class SignInCommand : LoginCommandBase
    {

        public SignInCommand(LoginViewModel LoginVM):base(LoginVM)
        {
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
                new Spark.MainWindow().ShowDialog();
            }
        }
    }
}
