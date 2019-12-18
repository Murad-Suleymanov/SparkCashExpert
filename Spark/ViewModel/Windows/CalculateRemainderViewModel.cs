using Spark.Commands.CalculateRemainder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.ViewModel.Windows
{
    public class CalculateRemainderViewModel : WindowViewModel
    {
        public CancelCommand cancelCommand => new CancelCommand(this);
    }
}
