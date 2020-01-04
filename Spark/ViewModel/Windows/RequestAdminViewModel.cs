using Spark.Commands.RequestAdminC;
using System.Windows;

namespace Spark.ViewModel.Windows
{
    public class RequestAdminViewModel : WindowViewModel
    {
        public SignInCommand SignIn => new SignInCommand(this);

        public DeleteRowViewModel DeleteRowVM { get; set; }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private Visibility _errorRoleVisibility = Visibility.Hidden;
        public Visibility RoleErrorVisibility
        {
            get => _errorRoleVisibility;
            set
            {
                _errorRoleVisibility = value;
                OnPropertyChanged(nameof(RoleErrorVisibility));
            }
        }


        private Visibility _emptyErrorVisibility = Visibility.Hidden;

        public Visibility EmptyErrorVisibility
        {
            get { return _emptyErrorVisibility = Visibility.Hidden; }
            set
            {
                _emptyErrorVisibility = value;
                OnPropertyChanged(nameof(EmptyErrorVisibility));
            }
        }

        private Visibility _noUserErrorVisibility = Visibility.Hidden;

        public Visibility NoUserErrorVisibility
        {
            get => _noUserErrorVisibility;
            set
            {
                _noUserErrorVisibility = value;
                OnPropertyChanged(nameof(NoUserErrorVisibility));
            }
        }

    }
}
