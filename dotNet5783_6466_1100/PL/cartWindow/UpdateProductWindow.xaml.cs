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
         Cart cart = new Cart() { CustomerAddress = "", CustomerEmail = "", CustomerName = "", Items = new List<BO.OrderItem?>(), TotalPrice = 0 };
        BO.Product? productBO = new BO.Product();
        CartPO cartPo = new();
        PO.OrderItemPO? orderItemPO=new();

        public UpdateProductWindow(Cart? cartBO, OrderItemPO productItem)
        {
            InitializeComponent();
            cart = cartBO!;
            cartPo = Tools.BoTOPoCart(cart!);
            //cart!.CustomerName = cartBO!.CustomerName;
            //cart.CustomerEmail = cartBO.CustomerEmail;
            //cart.CustomerAddress = cartBO.CustomerAddress;
            //cart.Items = cartBO!.Items;
            //cart!.TotalPrice = cartBO.TotalPrice;
            orderItemPO = productItem;
            DataContext = orderItemPO;
            productBO = bl.Product.GetProductbyId((int)productItem.ProductID!);
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            int amount = int.Parse(updateCB.Text);
            try
            {
                bl!.cart.UpdateProductInCart(cart, productBO!.ID, amount);
                cartPo = PL.Tools.BoTOPoCart(cart);
                orderItemPO!.Amount = amount;
                orderItemPO.TotalPrice = amount * orderItemPO.Price;

                Close();
                MessageBox.Show("seccssed");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
