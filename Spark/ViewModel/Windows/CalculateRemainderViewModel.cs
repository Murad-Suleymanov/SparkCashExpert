using Spark.Commands;

namespace Spark.ViewModel.Windows
{
    public class CalculateRemainderViewModel : WindowViewModel
    {
        public CalculateRemainderCancelCommand cancelCommand => new CalculateRemainderCancelCommand(this);
    }
}
