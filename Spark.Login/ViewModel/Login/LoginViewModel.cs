using Spark.Login.Commands.Login;
using Spark.Login.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Spark.Login.ViewModel
{
    public class LoginViewModel : WindowViewModel
    {
        public SignInCommand SignIn => new SignInCommand(this);
        public User User { get; set; } = new User();


        public Window Window { get; set; }

        private Visibility _errorVisibility = Visibility.Hidden;
        public Visibility ErrorVisibility
        {
            get => _errorVisibility;
            set
            {
                _errorVisibility = value;
                OnPropertyChanged(nameof(ErrorVisibility));
            }
        }
    }
}
