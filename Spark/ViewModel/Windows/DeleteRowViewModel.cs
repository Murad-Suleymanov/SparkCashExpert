using Spark.Commands.DeleteRow;

namespace Spark.ViewModel.Windows
{
    public class DeleteRowViewModel:WindowViewModel
    {
        public ResponseRowYesCommand responseYesCommand => new ResponseRowYesCommand(this);
        public MainWindowViewModel MainWindowVM { get; set; }
        public bool IsAccepted { get; set; }
    }
}
