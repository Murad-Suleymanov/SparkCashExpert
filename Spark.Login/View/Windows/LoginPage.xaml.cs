using System;
using Spark.Login.ViewModel;
using System.Windows;

namespace Spark.Login.View.Windows
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        LoginViewModel LoginVM;
        public LoginPage()
        {
            InitializeComponent();

            LoginVM = new LoginViewModel();
            LoginVM.Window = this;
            DataContext = LoginVM;
        }

        //public LoginPage()
        //{
        //    InitializeComponent();
        //}
    }
}
