using Spark.Login.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Login.Commands.Login
{
    public abstract class LoginCommandBase : BaseCommand
    {
        protected LoginViewModel LoginVM;
        protected LoginCommandBase(LoginViewModel LoginVM)
        {
            this.LoginVM = LoginVM;
        }

        public override bool CanExecute(object parameter) => true;
        public override event EventHandler CanExecuteChanged;
    }
}
