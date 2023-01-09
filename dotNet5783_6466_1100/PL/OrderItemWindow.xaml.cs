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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using BO;
using PL.cartWindow;
using PL.PO;
using MaterialDesignThemes.Wpf;

namespace PL
{
    /// <summary>
    /// Interaction logic for OrderItemWindow.xaml
    /// </summary>
    public partial class OrderItemWindow : Window
    {
        BlApi.IBL? bl = BlApi.Factory.GetBl() ?? throw new NullReferenceException("Missing bl");
        //BO.OrderItem OrderItemBO = new BO.OrderItem();
        //PO.OrderItemPO OrderItemPO = new PO.OrderItemPO();

        BO.Order OrderBO = new BO.Order();
        PO.OrderPO OrderPO = new PO.OrderPO();

        ObservableCollection<Order> Orders = new(); 
        public OrderItemWindow(BO.Order order)
        {
            InitializeComponent();
            //IEnumerableToObservable(bl.Order.GetOrder);

            //if (order.Items != null)
            //{
            //    OrderPO.ID = OrderBO.ID;
            //    OrderPO.CustomerName = OrderBO.CustomerName;
            //    OrderPO.CustomerEmail = OrderBO.CustomerEmail;
            //    OrderPO.CustomerAddress = OrderBO.CustomerAddress;
            //    //OrderPO.OrderStatus = OrderBO.OrderStatus; //need do status in PO
            //    OrderPO.OrderDate = (DateTime)OrderBO.OrderDate;
            //    OrderPO.ShipDate = (DateTime)OrderBO.ShipDate;
            //    OrderPO.DeliveryDate = (DateTime)OrderBO.DeliveryDate;
            //    OrderPO.Items = (List<OrderItemPO>)(from o in order.Items
            //                                               let name = bl.Order  .GetOrder(o.ProductID).CustomerName
            //                                        select new OrderItemPO()
            //                                               {
            //                                                   ID = o.ID,
            //                                                   Price = (double)o.Price,
            //                                                   IDProduct = o.ProductID,
            //                                                   Name = name,
            //                                                   Amount = (double)o.Amount,
            //                                                   TotalPrice = (double)o.TotalPrice

            //                                               }).ToList();
            //    OrderListView.ItemsSource = OrderItemPO.Items;

            //}

        }
        private void IEnumerableToObservable(IEnumerable<BO.OrderItem> listTOConvert)
        {
            //Orders.Clear();
            //foreach (var or in listTOConvert)
            //    Order.Items.Add(or);
        }
    }
}
