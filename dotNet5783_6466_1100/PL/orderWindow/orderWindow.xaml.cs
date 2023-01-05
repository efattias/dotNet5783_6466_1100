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
        //Cart cart = new Cart() { CustomerAddress = "", CustomerEmail = "", CustomerName = "", Items = new List<BO.OrderItem?>(), TotalPrice = 0 };


        public orderWindow(BO.OrderForList? order=null)
        {
            InitializeComponent();
            if(order!=null)
            {
                o = bl.Order.GetOrder(order.ID);
                IDTextBox.Text = o.ID.ToString();
                CustomerNameTextBox.Text = o.CustomerName!.ToString();
                MailTextBox.Text = o.CustomerEmail!.ToString();
                addressTextBox.Text=o.CustomerAddress!.ToString();
                

            }
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
