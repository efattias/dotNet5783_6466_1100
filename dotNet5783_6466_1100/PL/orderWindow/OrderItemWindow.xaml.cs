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
       // BlApi.IBL? bl = BlApi.Factory.GetBl() ?? throw new NullReferenceException("Missing bl");
        //BO.OrderItem OrderItemBO = new BO.OrderItem();
        //PO.OrderItemPO OrderItemPO = new PO.OrderItemPO();

       // BO.Order OrderBO = new BO.Order();
       // PO.OrderPO OrderPO = new PO.OrderPO();

        //ObservableCollection<Order> Orders = new(); 
        public OrderItemWindow(BO.Order order)
        {
            InitializeComponent();
            //IEnumerableToObservable(bl.Order.GetOrder);
            var orderitems = (from o in order.Items
                              select o).ToList();
            DataContext = orderitems;
    

        }
      
    }
}
