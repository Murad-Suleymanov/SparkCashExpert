using Spark.Commands;
using Spark.Commands.ChangeAmount;

namespace Spark.ViewModel.Windows
{
    public class ChangeAmountViewModel : WindowViewModel
    {
        public ChangeAmountCancelCommand cancelCommand => new ChangeAmountCancelCommand(this);
        public ChooseCountCommand countCommand => new ChooseCountCommand(this);

        public MainWindowViewModel MainVindowVM { get; set; }

        private string count;

        public string Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged(nameof(Count));
            }
        }
    }
}
