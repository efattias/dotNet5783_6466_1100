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
using System.Windows.Shapes;

namespace PL.cartWindow
{
    /// <summary>
    /// Interaction logic for personalDetailsCart.xaml
    /// </summary>
    public partial class personalDetailsCart : Window
    {
        public personalDetailsCart(BO.Cart cartBO)
        {
            InitializeComponent();
            //cartBO.CustomerName = customerNameTextBox.Text;
            //cartBO.CustomerAddress = customerAddressTextBox.Text;
            //cartBO.CustomerEmail = customerEmailTextBox.Text;
            details.DataContext= cartBO;

          
        }

        private void addDetails_Click(object sender, RoutedEventArgs e)
        {
           
            Close();
        
        }
    }
}
