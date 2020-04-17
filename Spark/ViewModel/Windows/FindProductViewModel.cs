using Spark.Commands;
using Spark.Dal.DataAccess;
using Spark.Dal.Domain.Abstract;
using Spark.Model;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Spark.ViewModel.Windows
{
    public class FindProductViewModel : WindowViewModel
    {
        readonly IUnitOfWork db;
        public FindProductViewModel()
        {
            db = new SqlUnifOfWork();
        }
        public FindProductCancelCommand cancelCommand => new FindProductCancelCommand(this);
        public ChooseProductCommand chooseProductCommand => new ChooseProductCommand(this);


        #region  //0-9 number and helper buttons
        public AddOneFPCommand addOneCommand => new AddOneFPCommand(this);
        public AddTwoFPCommand addTwoCommand => new AddTwoFPCommand(this);
        public AddThreeFPCommand addThreeCommand => new AddThreeFPCommand(this);
        public AddFourFPCommand addFourCommand => new AddFourFPCommand(this);
        public AddFiveFPCommand addFiveCommand => new AddFiveFPCommand(this);
        public AddSixFPCommand addSixCommand => new AddSixFPCommand(this);
        public AddSevenFPCommand addSevenCommand => new AddSevenFPCommand(this);
        public AddEightFPCommand addEightCommand => new AddEightFPCommand(this);
        public AddNineFPCommand addNineCommand => new AddNineFPCommand(this);
        public AddZeroFPCommand addZeroCommand => new AddZeroFPCommand(this);
        public AddDoubleZeroFPCommand addDoubleZeroCommand => new AddDoubleZeroFPCommand(this);
        public DeleteNumberFPCommand deleteNumberCommand => new DeleteNumberFPCommand(this);
        #endregion

        public MainWindowViewModel MainWindowVM { get; set; }
        public ProductDTO SelectedItem { get; set; }

        private ObservableCollection<ProductDTO> products = new ObservableCollection<ProductDTO>();

        public ObservableCollection<ProductDTO> Products
        {
            get => products;
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private string searchString;

        public string SearchString
        {
            get => searchString;
            set
            {
                searchString = value;

                if (!string.IsNullOrWhiteSpace(value) && searchString.Length >= 6)
                {
                    Products = Task.Run<ObservableCollection<ProductDTO>>(async () =>
                    {
                        ObservableCollection<ProductDTO> dTOs = await ProductDTO.ToDTOS(db.ProductDAORepository
                        .GetProductsLikeSearchString(searchString).GetAwaiter().GetResult());
                        return dTOs;
                    }).GetAwaiter().GetResult();
                    if (Products.Count == 0)
                        ErrorVisibility = Visibility.Visible;
                }
                else
                {
                    Products = new ObservableCollection<ProductDTO>();
                    ErrorVisibility = Visibility.Hidden;
                }
                OnPropertyChanged(nameof(SearchString));
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
