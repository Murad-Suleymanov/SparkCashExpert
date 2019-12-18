using Spark.Commands.ChangeAmount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.ViewModel.Windows
{
    public class ChangeAmountViewModel:WindowViewModel
    {
        public CancelCommand cancelCommand => new CancelCommand(this);
        private int Exam;

        public int EXAM
        {
            get { return Exam; }
            set { Exam = value; }
        }

    }
}
