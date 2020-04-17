using Spark.Commands;
using Spark.Commands.ChangeAmount;
using System.Windows;

namespace Spark.ViewModel.Windows
{
    public class ChangeAmountViewModel : WindowViewModel
    {
        public ChangeAmountCancelCommand cancelCommand => new ChangeAmountCancelCommand(this);
        public ChooseCountCommand countCommand => new ChooseCountCommand(this);

        //0-9 number and helper buttons add 
        #region Buttons
        public AddOneCommand addOneCommand => new AddOneCommand(this);
        public AddTwoCommand addTwoCommand => new AddTwoCommand(this);
        public AddThreeCommand addThreeCommand => new AddThreeCommand(this);
        public AddFourCommand addFourCommand => new AddFourCommand(this);
        public AddFiveCommand addFiveCommand => new AddFiveCommand(this);
        public AddSixCommand addSixCommand => new AddSixCommand(this);
        public AddSevenCommand addSevenCommand => new AddSevenCommand(this);
        public AddEightCommand addEightCommand => new AddEightCommand(this);
        public AddNineCommand addNineCommand => new AddNineCommand(this);
        public AddPointCommand addPointCommand => new AddPointCommand(this);
        public AddZeroCommand addZeroCommand => new AddZeroCommand(this);
        #endregion


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

        private Visibility _errorVisibility = Visibility.Hidden;

        public Visibility ErrorVisibility
        {
            get => _errorVisibility;
            set
            {
                _errorVisibility = value;
                OnPropertyChanged(nameof(ErrorVisibility));
            }
        }

    }
}
