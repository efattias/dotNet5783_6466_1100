

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

namespace PL.productWindow
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        BlApi.IBL? bl = BlApi.Factory.GetBl() ?? throw new NullReferenceException("Missing bl") ;
     
        //IBL bl =  Factory.GetBl();
        BO.Product? p= new BO.Product();
        Cart cart = new Cart() { CustomerAddress = "", CustomerEmail = "", CustomerName = "", Items = new List<BO.OrderItem?>(), TotalPrice = 0 };


        public ProductWindow(BO.ProductForList? updateP=null)
        {
            InitializeComponent();
            categoryComboBox.ItemsSource=Enum.GetValues(typeof(BO.Category));
            if (updateP != null)
            {
                addToButton.Visibility = Visibility.Hidden;
                p = bl.Product.GetProductbyId(updateP.ID);
                UpdateButton.DataContext = p;
                IDTextBox.Text = p!.ID.ToString();
                NameTextBox.Text=p!.Name.ToString();
                PriceTextBox.Text = p!.Price.ToString();
                AmountOfItemTextBox.Text = p!.InStock.ToString();
                categoryComboBox.SelectedItem=p!.Category;
            }
            else
            {
                UpdateButton.Visibility = Visibility.Hidden;
                addToButton.DataContext=p;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            //create the product
            try
            {
                p!.ID = int.Parse(IDTextBox.Text);
                p!.Name= NameTextBox.Text;
                p!.InStock = int.Parse(AmountOfItemTextBox.Text);
                p!.Category = (BO.Category?)categoryComboBox.SelectedItem;
                p!.Price = double.Parse(PriceTextBox.Text);

                bl!.Product.UpdateDetailProduct(p);
                Close();
                MessageBox.Show("המוצר עודכן בהצלחה");
            }
            catch (Exception x)
            { MessageBox.Show(x.Message); }
        }

        private void addToButton_Click(object sender, RoutedEventArgs e)
        {
            //create the product
            try
            {
                p!.ID = int.Parse(IDTextBox.Text);
                p!.Name = NameTextBox.Text;
                p!.InStock = int.Parse(AmountOfItemTextBox.Text);
                p!.Category = (BO.Category?)categoryComboBox.SelectedItem;
                p!.Price = double.Parse(PriceTextBox.Text);
                bl!.Product.AddProduct(p);
                Close();
                MessageBox.Show("המוצר הוסף בהצלחה");
            }
            catch (Exception x)
            { MessageBox.Show(x.Message); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bl.cart.AddProductToCart(cart, p!.ID);
            this.Close();

        }
    }
}
