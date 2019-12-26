using Spark.Commands;

namespace Spark.ViewModel.Windows
{
    public class ChangeAmountViewModel : WindowViewModel
    {
        public ChangeAmountCancelCommand cancelCommand => new ChangeAmountCancelCommand(this);
        private int Exam;

        public int EXAM
        {
            get { return Exam; }
            set { Exam = value; }
        }

    }
}
