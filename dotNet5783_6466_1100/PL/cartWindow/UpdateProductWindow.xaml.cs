using BO;
using MaterialDesignThemes.Wpf;
using PL.PO;
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
    /// Interaction logic for UpdateProductWindow.xaml
    /// </summary>
    public partial class UpdateProductWindow : Window
    {
        BlApi.IBL? bl = BlApi.Factory.GetBl() ?? throw new NullReferenceException("Missing bl");
        public Cart cart = new Cart() { CustomerAddress = "", CustomerEmail = "", CustomerName = "", Items = new List<BO.OrderItem?>(), TotalPrice = 0 };
        BO.Product? p = new BO.Product();
        private OrderItemPO? product;

        public UpdateProductWindow(Cart? cartBO, OrderItemPO productItem)
        {
            InitializeComponent();
            cart!.CustomerName = cartBO!.CustomerName;
            cart.CustomerEmail = cartBO.CustomerEmail;
            cart.CustomerAddress = cartBO.CustomerAddress;
            cart.Items = cartBO!.Items;
            cart!.TotalPrice = cartBO.TotalPrice;

            product = productItem;
            DataContext = product;
            p!.ID = (int)productItem.ProductID;
            p!.Price = productItem.Price;
            p!.InStock = (int)productItem.Amount;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            p!.InStock = int.Parse(AmountOfItemTextBox.Text);
            try
            {
                bl!.cart.UpdateProductInCart(cart, p!.ID, (int)p.InStock);

                Close();
                MessageBox.Show("seccssed");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
