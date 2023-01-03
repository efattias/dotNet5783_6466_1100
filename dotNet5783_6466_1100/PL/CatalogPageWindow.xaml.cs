using BO;
using PL.productWindow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for CatalogPageWindow.xaml
    /// </summary>
    public partial class CatalogPageWindow : Page
    {
        BlApi.IBL? bl = BlApi.Factory.GetBl() ?? throw new NullReferenceException("Missing bl");
        ObservableCollection<ProductForList> productListPO = new();
        public CatalogPageWindow()
        {
            InitializeComponent();
            IEnumerableToObservable(bl.Product.getProductForList());
            productListV.DataContext = productListPO;
            categorySelector.ItemsSource = Enum.GetValues(typeof(BO.Category));
        }

        private void IEnumerableToObservable(IEnumerable<ProductForList> listTOConvert)
        {
            productListPO.Clear();
            foreach (var p in listTOConvert)
                productListPO.Add(p);
        }
        private void categorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (categorySelector.SelectedItem is BO.Category.הכל)
                IEnumerableToObservable(bl!.Product.getProductForList());
            else if (categorySelector.SelectedItem is BO.Category)
                IEnumerableToObservable(bl!.Product.GetPartOfProduct(p => p.Category == (BO.Category)categorySelector.SelectedItem));
            else if (categorySelector.SelectedItem is "")
                IEnumerableToObservable(bl!.Product.getProductForList());
        }

        private void doubleClickUpdateProduct(object sender, MouseButtonEventArgs e) => new ProductWindow((BO.ProductForList)productListV.SelectedItem).Show();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CartWindow caWindow = new CartWindow();
            caWindow.Show();
        }
    }
}
