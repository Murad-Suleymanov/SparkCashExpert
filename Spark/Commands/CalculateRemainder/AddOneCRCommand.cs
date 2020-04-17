using Spark.ViewModel.Windows;
using System;

namespace Spark.Commands.CalculateRemainder
{
    public class AddOneCRCommand : CalculateRemainderCommandBase
    {
        readonly CalculateRemainderViewModel calculateRemainderVM;
        public AddOneCRCommand(CalculateRemainderViewModel calculateRemainderVM)
            : base(calculateRemainderVM)
        {
            this.calculateRemainderVM = calculateRemainderVM;
        }

        public override void Execute(object parameter)
        {
            if (calculateRemainderVM.IsFocusedWithCartTxt)
                calculateRemainderVM.WithCart += "1";
            else
                calculateRemainderVM.WithCash += "1";
        }
    }
}
