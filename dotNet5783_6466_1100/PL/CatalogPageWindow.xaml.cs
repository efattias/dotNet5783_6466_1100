using BO;
using MaterialDesignThemes.Wpf;
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
        BO.Product? p = new BO.Product();
        Cart cart = new Cart() { CustomerAddress = "", CustomerEmail = "", CustomerName = "", Items = new List<BO.OrderItem?>(), TotalPrice = 0 };


        ObservableCollection<ProductForList> productListPO = new();
        public CatalogPageWindow()
        {
            InitializeComponent();
            IEnumerableToObservable(bl.Product.getProductForList());
            PList.DataContext = productListPO;
            //productListV.DataContext = productListPO;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CartWindow caWindow = new CartWindow();
            caWindow.Show();
        }

        private void AddProductToCart_Click(object sender, RoutedEventArgs e)
        
        {
            try
            {
               cart= bl.cart.AddProductToCart(cart, (PList.SelectedItem as ProductForList).ID);
                MessageBox.Show("seccssed");
                //bl.cart.AddProductToCart(cart, p!.ID);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

       
    }
}
