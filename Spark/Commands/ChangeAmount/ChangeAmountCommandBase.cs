using Spark.ViewModel.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Commands.ChangeAmount
{
    public abstract class ChangeAmountCommandBase : BaseCommand
    {
        public ChangeAmountCommandBase(ChangeAmountViewModel changeAmountVM)
        {
        }
    }
}
