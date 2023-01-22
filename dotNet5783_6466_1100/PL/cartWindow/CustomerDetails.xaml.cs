using BO;
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

namespace PL.cartWindow
{
    /// <summary>
    /// Interaction logic for CustomerDetails.xaml
    /// </summary>
    public partial class CustomerDetails : Page
    {
        Frame frame;
        public CustomerDetails( int orderNum ,Frame f)
        {
            InitializeComponent();
            orderNumTextBox.Text = orderNum.ToString();
            frame= f;
        }

        private void backToCatalog_Click(object sender, RoutedEventArgs e)
        {
            MainPage page = new MainPage(frame);
            frame.Content = page; 
        }
    }
}
