using Spark.ViewModel.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Commands.CalculateRemainder
{
    public class CancelCommand : CalculateRemainderCommandBase
    {
        CalculateRemainderViewModel calculateRemainderVM;
        public CancelCommand(CalculateRemainderViewModel calculateRemainderVM):base(calculateRemainderVM)
        {
            this.calculateRemainderVM = calculateRemainderVM;
        }

        public override void Execute(object parameter)
        {
            calculateRemainderVM.CurrentWindow.Close();
        }
    }
}
