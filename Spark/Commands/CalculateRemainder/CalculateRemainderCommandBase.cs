using Spark.ViewModel.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Commands.CalculateRemainder
{
    public abstract class CalculateRemainderCommandBase:BaseCommand
    {
        public CalculateRemainderCommandBase(CalculateRemainderViewModel calculateRemainderVM)
        {
        }
    }
}
