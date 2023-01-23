using BO;
using DO;
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

namespace PL.orderWindow
{
    /// <summary>
    /// Interaction logic for orderWindow.xaml
    /// </summary>
    public partial class orderWindow : Window
    {
        BlApi.IBL? bl = BlApi.Factory.GetBl() ?? throw new NullReferenceException("Missing bl");

        //IBL bl =  Factory.GetBl();
        BO.Order? o = new BO.Order();
        PO.OrderForListPO orPO = new PO.OrderForListPO();
        //Cart cart = new Cart() { CustomerAddress = "", CustomerEmail = "", CustomerName = "", Items = new List<BO.OrderItem?>(), TotalPrice = 0 };


        public orderWindow(PO.OrderForListPO? order=null)
        {
            InitializeComponent();
            if(order!=null)
            {
                orPO = order;
                DataContext = orPO;

                o = bl.Order.GetOrder((int)order.ID!) ?? throw new NullReferenceException("הזמנה נאל");
                //for order fields
                addressTextBox.Text = o!.CustomerAddress!.ToString();
                MailTextBox.Text = o!.CustomerEmail!.ToString();
                orderDateTextBox.Text= o.OrderDate.ToString();
                ShipDateTextBox.Text = o.ShipDate.ToString();
                DeliveryDateTextBox.Text=o.DeliveryDate.ToString();

                if(o.ShipDate is not null && o.DeliveryDate is not null)
                {
                    updateShipDate.Visibility = Visibility.Hidden;
                    updateDeliveryDate.Visibility = Visibility.Hidden;
                }
                else if(o.ShipDate is null )
                {
                    //   updateShipDate.Visibility = Visibility.visible;
                    updateDeliveryDate.Visibility = Visibility.Hidden;
                }

               else if(o.DeliveryDate is null)
                {
                    updateShipDate.Visibility = Visibility.Hidden;
                }

                //IDTextBox.Text = o.ID.ToString();
                //CustomerNameTextBox.Text = o.CustomerName!.ToString();
                //MailTextBox.Text = o.CustomerEmail!.ToString();
                //addressTextBox.Text=o.CustomerAddress!.ToString();
                

            }
        }

        private void updateShipDate_Click(object sender, RoutedEventArgs e)
        {
            if (o != null)
            {
                bl!.Order.UpdateShipOrder(o.ID);
                orPO.OrderStatus = PO.Status.נשלח;
                
             
                Close();
            }
        }

        private void updateDeliveryDate_Click(object sender, RoutedEventArgs e)
        {
            if(o!=null)
            {
                bl!.Order.UpdateProvisionOrder(o.ID);
                orPO.OrderStatus = PO.Status.נמסר;
                
                Close();
            }
        }

        private void ShowItemList_Click(object sender, RoutedEventArgs e)
        {
            OrderItemWindow orderItemWindow=new OrderItemWindow(o!);
            orderItemWindow.Show();
        }
    }

 


    //public ProductWindow(BO.ProductForList? updateP = null)
    //{
    //    InitializeComponent();
    //    categoryComboBox.ItemsSource = Enum.GetValues(typeof(BO.Category));
    //    if (updateP != null)
    //    {
    //        addToButton.Visibility = Visibility.Hidden;
    //        p = bl.Product.GetProductbyId(updateP.ID);
    //        UpdateButton.DataContext = p;
    //        IDTextBox.Text = p!.ID.ToString();
    //        NameTextBox.Text = p!.Name.ToString();
    //        PriceTextBox.Text = p!.Price.ToString();
    //        AmountOfItemTextBox.Text = p!.InStock.ToString();
    //        categoryComboBox.SelectedItem = p!.Category;
    //    }
    //    else
    //    {
    //        UpdateButton.Visibility = Visibility.Hidden;
    //        addToButton.DataContext = p;
    //    }
    //}
}
