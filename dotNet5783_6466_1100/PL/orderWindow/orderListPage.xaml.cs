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

namespace PL.orderWindow
{
    /// <summary>
    /// Interaction logic for orderListPage.xaml
    /// </summary>
    public partial class orderListPage : Page
    {
        BlApi.IBL? bl = BlApi.Factory.GetBl() ?? throw new NullReferenceException("Missing bl");
        // private IBL bl = Factory.GetBl();
        ObservableCollection<OrderForList> orderListPO = new();

        public orderListPage()
        {
            InitializeComponent();
            IEnumerableToObservable(bl.Order.getOrderForList());
            orderListV.DataContext = orderListPO;
            //productListView.ItemsSource = bl.Product.getProductForList();
            orderSelector.ItemsSource = Enum.GetValues(typeof(BO.Status));
            // categorySelector.SelectedItem = BO.Category.All;
        }

        private void categorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (orderSelector.SelectedItem is BO.Status.הכל)
                IEnumerableToObservable(bl!.Order.getOrderForList());
            else if (orderSelector.SelectedItem is BO.Status)
                IEnumerableToObservable(bl!.Order.GetPartOfOrder(o => o.OrderStatus == (BO.Status)orderSelector.SelectedItem));
            else if (orderSelector.SelectedItem is "")
                IEnumerableToObservable(bl!.Order.getOrderForList());
        }
        private void IEnumerableToObservable(IEnumerable<OrderForList> listTOConvert)
        {
            orderListPO.Clear();
            foreach (var o in listTOConvert)
                orderListPO.Add(o);

        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow window = new ProductWindow();
            window.Show();
            //  IEnumerableToObservable(productListPO);
        }

        private void doubleClickUpdateOrder(object sender, MouseButtonEventArgs e) => new ProductWindow((BO.ProductForList)orderListV.SelectedItem).Show();


    }
}

