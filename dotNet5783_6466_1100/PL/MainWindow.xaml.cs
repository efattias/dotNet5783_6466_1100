
using PL.Cwindows;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private IBL bL = Factory.GetBl();
        BlApi.IBL? bl = BlApi.Factory.GetBl() ?? throw new NullReferenceException("Missing bl");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void showProductListWindow_Click(object sender, RoutedEventArgs e)
        {
            //productListWindow window = new productListWindow();
            //window.Show();
            //ProductListPage page = new ProductListPage();
            //this.Content = page;
            OrderTrackingPage orderTrackingPage = new OrderTrackingPage();
            this.Content = orderTrackingPage;
        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            //ManagerButton.Visibility = Visibility.Hidden;
            //ManagerButton.IsEnabled = false;
            //ManagerWindow managerWindow = new ManagerWindow();
            //managerWindow.Show();
            ManagerPage mPage = new ManagerPage();
            this.Content = mPage;
        }

        private void customerButton_Click(object sender, RoutedEventArgs e)
        {
            CatalogPageWindow catalogPage = new CatalogPageWindow();
            this.Content= catalogPage;
            //ProductListPage page = new ProductListPage();
            //this.Content = page;
        }
    }
}
