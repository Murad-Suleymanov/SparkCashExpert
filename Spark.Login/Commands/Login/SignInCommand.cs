using Spark.Login.ViewModel;
using Spark.ViewModel.Windows;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Spark.Login.Commands.Login
{
    public class SignInCommand : LoginCommandBase
    {
        MainWindowViewModel MainWindowVM;
        public SignInCommand(LoginViewModel LoginVM):base(LoginVM)
        {
        }

        public override void Execute(object parameter)
        {
#if !DEBUG
            string password = (parameter as PasswordBox)?.Password;
            if (string.IsNullOrEmpty(password))
                LoginVM.ErrorVisibility = Visibility.Visible;
            if (string.IsNullOrEmpty(LoginVM.User.UserName))
                LoginVM.ErrorVisibility = Visibility.Visible;
            else
            {
#else
            Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    Application.Current.Dispatcher?.Invoke(() => { LoginVM.Window.Close(); });
                });

            new Spark.MainWindow(new MainWindowViewModel { Username=LoginVM.User.UserName,CashierName=LoginVM.User.UserName }).ShowDialog();
         }
        //}
    }
#endif 
}
