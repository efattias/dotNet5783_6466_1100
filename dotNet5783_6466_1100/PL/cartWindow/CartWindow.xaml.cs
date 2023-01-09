using BO;
using PL.cartWindow;
using PL.PO;
using PL.productWindow;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        BlApi.IBL? bl = BlApi.Factory.GetBl() ?? throw new NullReferenceException("Missing bl");
        BO.Cart? cartBO = new BO.Cart();
        PO.CartPO? cartPO = new PO.CartPO();
        public CartWindow(BO.Cart cart)
        {
            InitializeComponent();
            //CartListView.ItemsSource=c.Items;
            cartBO = cart;


            if (cart.Items != null)
            {
                cartPO.Name = cartBO.CustomerName;
                cartPO.Email = cartBO.CustomerEmail;
                cartPO.Address = cartBO.CustomerAddress;
                cartPO.TotalPrice = (double)cartBO.TotalPrice;
                cartPO.OrderItemList = (List<OrderItemPO>)(from o in cart.Items
                                                           let name = bl.Product.GetProductbyId(o.ProductID).Name
                                                           select new OrderItemPO()
                                                           {
                                                               ID = o.ID,
                                                               Price = (double)o.Price,
                                                               IDProduct = o.ProductID,
                                                               Name = name,
                                                               Amount = (double)o.Amount,
                                                               TotalPrice = (double)o.TotalPrice

                                                           }).ToList();
                CartListView.ItemsSource = cartPO.OrderItemList;


            }
          
        }

        private void completeCart_Click(object sender, RoutedEventArgs e)
        {
            personalDetailsCart detailsWindow= new personalDetailsCart(cartBO);
            detailsWindow.ShowDialog();
            
            bl.cart.MakeCart(cartBO);
            cartBO= null;
            cartPO = null;
            
            Close();
        }

     
        
    }
}
