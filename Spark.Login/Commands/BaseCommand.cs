using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Spark.Login.Commands
{
    public abstract class BaseCommand : ICommand
    {
        /// <summary>
        /// This area for implement IUnitOfWork 
        /// </summary>
        
        public virtual event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter) => true;

        public abstract void Execute(object parameter);
    }
}
