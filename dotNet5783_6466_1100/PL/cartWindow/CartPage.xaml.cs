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


            //if (cart.Items != null)
            //{
            //    cartPO.CustomerName = cartBO.CustomerName;
            //    cartPO.CustomerEmail = cartBO.CustomerEmail;
            //    cartPO.CustomerAddress = cartBO.CustomerAddress;
            //    cartPO.TotalPrice = (double)cartBO.TotalPrice;
            //    cartPO.Items = (List<OrderItemPO>)(from o in cart.Items
            //                                               let name = bl.Product.GetProductbyId(o.ProductID).Name
            //                                               select new OrderItemPO()
            //                                               {
            //                                                   ID = o.ID,
            //                                                   Price = (double)o.Price,
            //                                                   ProductID = o.ProductID,
            //                                                   Name = name,
            //                                                   Amount = (double)o.Amount,
            //                                                   TotalPrice = (double)o.TotalPrice

            //                                               }).ToList();
            //cartListView.ItemsSource = cartPO.Items;
            //cartListView.DataContext = cartPO.Items;
            DataContext = cartPO;

            if (cartBO.Items.Count() == 0)
                completeCart.IsEnabled = false;

        }

        private void completeCart_Click(object sender, RoutedEventArgs e)
        {
            if (cartBO.Items.Count() != 0)
            {
                personalDetailsCart detailsWindow = new personalDetailsCart(cartBO);
                detailsWindow.ShowDialog();

                List<BO.OrderItem>? orderItemsBO = new List<BO.OrderItem>();
                try
                {
                  int orderId=  bl!.cart.MakeCart(cartBO);
                    // cart = new();
                    //  cartBO.Items = new();
                    // DataContext= cartBO;

                    cartBO.CustomerName = null;
                    cartBO.CustomerAddress = null;
                    cartBO.CustomerEmail = null;
                    foreach (BO.OrderItem item in cartBO.Items.ToList())
                    {
                        bl.cart.UpdateProductInCart(cartBO, item.ProductID, 0);
                    }

                    //cartBO.Items.ForEach(delegate (BO.OrderItem item)
                    //{
                    //    bl.cart.UpdateProductInCart(cartBO, item.ProductID, 0);
                    //});
                    if (cartBO.Items.Count() == 0)
                        completeCart.IsEnabled = false;
                    CustomerDetails page = new CustomerDetails(orderId,frame);
                    frame.Content = page;
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }


                //to clear the cart to the next time
                // cartBO?.Items?.Clear();

                //  cartBO = null;
                // cartPO = null;
              
                //NavigationService.GoBack();
            }
        }

        private void deleteCart_Click(object sender, RoutedEventArgs e)
        {

            cartBO.Items.Clear();
            cartPO.Items.Clear();
            cartBO.TotalPrice = 0;
            cartPO.TotalPrice = 0;
        }

        //private void doubleClickUpdateProduct(object sender, MouseButtonEventArgs e)
        //{
        //    var product = (PO.OrderItemPO)cartListView.SelectedItem;
        //    //new UpdateProductWindow(cartPO, product).ShowDialog;
        //    UpdateProductWindow up = new UpdateProductWindow(cartBO, product);
        //    up.ShowDialog();
        //}

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PO.OrderItemPO? orderItemPO = ((Button)(sender)).DataContext as PO.OrderItemPO;
                //BO.OrderItem? orderItemBO = new BO.OrderItem();
                //orderItemBO.ID = orderItemPO.ID;//לא מקבל ID
                //orderItemBO.Name = orderItemPO.Name;
                //orderItemBO.ProductID = orderItemPO.ProductID;
                //orderItemBO.Price = orderItemPO.Price;
                //orderItemBO.Amount = (int)orderItemPO.Amount;
                //orderItemBO.TotalPrice = orderItemPO.TotalPrice;

                //BO.OrderItem? orderItemBO= cartListView.SelectedItem as BO.OrderItem;
                int id = orderItemPO?.ProductID ?? 0;
                // int zeroAmount = 0;


                bl.cart.UpdateProductInCart(cartBO, id, 0);

                cartPO!.Items!.Remove(orderItemPO);
                cartPO.TotalPrice = cartPO.TotalPrice - orderItemPO.Price * orderItemPO.Amount;

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
        //private void IEnumerableToObservable(IEnumerable<BO.OrderItem> listTOConvert)
        //{
        //    var listPO = (from p in listTOConvert
        //                  select new PO.OrderItemPO
        //                  {
        //                      ID = p.ID,
        //                      Price = (double)p.Price,
        //                      ProductID = p.ProductID,
        //                      TotalPrice = (double)p.TotalPrice,
        //                      Amount = (double)p.Amount,
        //                      Name = p.Name

        //                  }).ToList();
        //    cartPO.Items.Clear();
        //    foreach (var p in listPO)
        //        cartPO.Items.Add(p);

        //}
        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //        PO.OrderItemPO? orderItemPO = cartListView.SelectedItem as PO.OrderItemPO;
            //        BO.OrderItem? orderItemBO = new BO.OrderItem();
            //        orderItemBO.ID = orderItemPO.ID;
            //        orderItemBO.Name = orderItemPO.Name;
            //        orderItemBO.ProductID = (int)orderItemPO.ProductID;
            //        orderItemBO.Price = orderItemPO.Price;
            //        orderItemBO.Amount = (int)orderItemPO.Amount;
            //        orderItemBO.TotalPrice = orderItemPO.TotalPrice;

            //        int id = orderItemBO.ProductID;
            //        int amount = 2;
            //        bl.cart.UpdateProductInCart(cartBO, id, amount);
            //        cartPO.Items = (List<OrderItemPO>)(from o in cartBO.Items
            //                                                   let name = bl.Product.GetProductbyId(o.ProductID).Name
            //                                                   select new OrderItemPO()
            //                                                   {
            //                                                       ID = o.ID,
            //                                                       Price = (double)o.Price,
            //                                                       ProductID = o.ProductID,
            //                                                       Name = name,
            //                                                       Amount = (int?)o.Amount,
            //                                                       TotalPrice = (double)o.TotalPrice

            //                                                   }).ToList();
            //        cartPO.TotalPrice = (double)cartBO.TotalPrice;


            //        MessageBox.Show("seccssed");
            //    }
            //    catch (Exception x)
            //    {
            //        MessageBox.Show(x.Message);
            //    }
            //}
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            //int amount = int.Parse(.Text);
            //try
            //{
            //    bl!.cart.UpdateProductInCart(cart, productBO!.ID, amount);
            //    cartPo = PL.Tools.BoTOPoCart(cart);
            //    orderItemPO.Amount = amount;
            //    orderItemPO.TotalPrice = amount * orderItemPO.Price;

            //    Close();
            //    MessageBox.Show("seccssed");
            //}
            //catch (Exception x)
            //{
            //    MessageBox.Show(x.Message);
            //}
        }

        private void cartListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var product = (PO.OrderItemPO)cartlistView.SelectedItem;
            UpdateProductWindow up = new UpdateProductWindow(cartBO, product);
            up.ShowDialog();
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
                PO.OrderItemPO item = new();
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

                bl.cart.UpdateProductInCart(cartBO, (int)item.ProductID, amount);
                item = cartPO.Items.FirstOrDefault(x => x.ProductID == item.ProductID);
                cartPO.TotalPrice = cartBO.TotalPrice;
                if (amount == 0)
                {
                    cartPO.Items.Remove(item);
                    cartPO.TotalPrice = cartBO.TotalPrice;
                    return;
                }
                item.Amount = amount;
                item.TotalPrice = item.Amount * item.Price;
            }
            catch (BO.ProductOutOfStockException ex)
            {
                MessageBox.Show("אין עוד מהמוצר הזה במלאי" +
                   "", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
        }
        private void UpdateSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var orderItem = sender as OrderItemPO;
           
        }
    }
}
