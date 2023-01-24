using BO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL.cartWindow
{
    /// <summary>
    /// Interaction logic for CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {

        BlApi.IBL? bl = BlApi.Factory.GetBl() ?? throw new NullReferenceException("Missing bl");
        BO.Cart? cartBO = new();
        PO.CartPO? cartPO = new();
        Frame frame;
        public CartPage(BO.Cart cart,Frame f )
        {
            InitializeComponent();
            //CartListView.ItemsSource=c.Items;
            cartBO = cart;
            cartPO = PL.Tools.BoTOPoCart(cartBO);
            frame=f;           
            DataContext = cartPO;

            if (cartBO!.Items!.Count() == 0)
                completeCart.IsEnabled = false;
             
        }

        private void completeCart_Click(object sender, RoutedEventArgs e)
        {
            if (cartBO!.Items!.Count() != 0)
            {
                personalDetailsCart detailsWindow = new personalDetailsCart(cartBO);
                detailsWindow.ShowDialog();

                List<BO.OrderItem>? orderItemsBO = new List<BO.OrderItem>();
                try
                {
                  int orderId=  bl!.cart.MakeCart(cartBO);
                   
                    cartBO.CustomerName = null;
                    cartBO.CustomerAddress = null;
                    cartBO.CustomerEmail = null;
                    foreach (BO.OrderItem? item in cartBO!.Items!.ToList())
                    {
                        bl.cart.UpdateProductInCart(cartBO, item!.ProductID, 0);
                    }
                
                    if (cartBO!.Items!.Count() == 0)
                        completeCart.IsEnabled = false;
                    CustomerDetails page = new CustomerDetails(orderId,frame);
                    frame.Content = page;
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }

            }
        }

        private void deleteCart_Click(object sender, RoutedEventArgs e)
        {

            cartBO!.Items!.Clear();
            cartPO!.Items!.Clear();
            cartBO.TotalPrice = 0;
            cartPO.TotalPrice = 0;
        }


        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PO.OrderItemPO? orderItemPO = ((Button)(sender)).DataContext as PO.OrderItemPO;               
                int id = orderItemPO?.ProductID ?? 0;
              
                bl!.cart!.UpdateProductInCart(cartBO, id, 0);

                cartPO!.Items!.Remove(orderItemPO!);
                cartPO.TotalPrice = cartPO.TotalPrice - orderItemPO!.Price * orderItemPO.Amount;

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }    
        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {

            var t = (TextBox)sender;
            int amount;
            if (t.Text != "")
            {               
                amount = int.Parse(t.Text);
                if (amount == 0)
                    amount = 1;
                try
                {
                    UpdateAmount(sender, amount, true);
                }
                catch
                {
                    MessageBox.Show("אין עוד מהמוצר הזה במלאי" +
                   "", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                    amount = 1;
                }
            }
        }
        private void UpdateAmount(object sender, int amount, bool isTextBox = false)
        {
            try
            {
                PO.OrderItemPO? item = new();
                TextBox t;
                Button b;
                if (isTextBox)
                {
                    t = (TextBox)sender;
                    item = (PO.OrderItemPO)t.DataContext;
                }
                else
                {
                    b = (Button)sender;
                    item = (PO.OrderItemPO)b.DataContext;
                }

                bl!.cart.UpdateProductInCart(cartBO, (int)item!.ProductID!, amount);
                item = cartPO!.Items!.FirstOrDefault(x => x!.ProductID! == item!.ProductID!);
                cartPO.TotalPrice = cartBO!.TotalPrice;
                if (amount == 0)
                {
                    cartPO!.Items!.Remove(item!);
                    cartPO.TotalPrice = cartBO.TotalPrice;
                    return;
                }
                item!.Amount = amount;
                item.TotalPrice = item.Amount * item.Price;
            }
            catch (BO.ProductOutOfStockException )
            {
                MessageBox.Show("אין עוד מהמוצר הזה במלאי" +
                   "", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
        }
       

        private void backToCatelog_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
