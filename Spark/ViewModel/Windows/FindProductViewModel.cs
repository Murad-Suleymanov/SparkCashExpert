using Spark.Commands;
using Spark.Dal.DataAccess;
using Spark.Dal.Domain.Abstract;
using Spark.Model;
using System.Collections.ObjectModel;
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
