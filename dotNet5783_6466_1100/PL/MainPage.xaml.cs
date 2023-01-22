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
using static System.Net.Mime.MediaTypeNames;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Frame frame;
        public MainPage(Frame f)
        {
            InitializeComponent();
            frame = f;
        }
        private void showProductListWindow_Click(object sender, RoutedEventArgs e)
        {
            //productListWindow window = new productListWindow();
            //window.Show();
            //ProductListPage page = new ProductListPage();
            //this.Content = page;
            OrderTrackingPage orderTrackingPage = new OrderTrackingPage(frame);
            frame.Content = orderTrackingPage;
        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            //ManagerButton.Visibility = Visibility.Hidden;
            //ManagerButton.IsEnabled = false;
            //ManagerWindow managerWindow = new ManagerWindow();
            //managerWindow.Show();
          //  ManagerPage mPage = new ManagerPage();
          ////  this.Content = mPage;
          //frame.Content = mPage;

            ManagerButton.Visibility = Visibility.Hidden;
            ManagerButton.IsEnabled = false;

            managetLogin.Visibility = Visibility.Visible;
            managetLogin.IsEnabled = true;

        }

        private void customerButton_Click(object sender, RoutedEventArgs e)
        {
            CatalogPageWindow catalogPage = new CatalogPageWindow(frame);
            frame.Content= catalogPage;
            //ProductListPage page = new ProductListPage();
            //this.Content = page;
        }

        private void CloseManagerLogIn_Click(object sender, RoutedEventArgs e)
        {
            ManagerButton.Visibility = Visibility.Visible;
            ManagerButton.IsEnabled = true;

            managetLogin.Visibility = Visibility.Hidden;
            managetLogin.IsEnabled = false;

            PasswordBox.Password = "";
        }

        private void ManagerlogInWithPassword_Click(object sender, RoutedEventArgs e)
        {
            EnterPassword();
        }

        private void EnterPressed_KeyDown(object sender, KeyEventArgs e)
        
        {
            if (e.Key == Key.Enter) EnterPassword();
        }

        private void EnterPassword()
        {
            if (PasswordBox.Password == "1234")
            {
                ManagerPage homeManager = new(frame);
                PasswordBox.Password = "";
                frame.Content = homeManager;

                ManagerButton.Visibility = Visibility.Visible;
                ManagerButton.IsEnabled = true;

                managetLogin.Visibility = Visibility.Hidden;
                managetLogin.IsEnabled = false;
                //homeManager.ShowDialog();
            }
            else
            {
                MessageBox.Show("סיסמה שגויה");
                PasswordBox.Password = "";
            }
        }

    }
}
