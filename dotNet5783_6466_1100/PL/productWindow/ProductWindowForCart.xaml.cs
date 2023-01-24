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
using System.Windows.Shapes;

namespace PL.productWindow
{
    /// <summary>
    /// Interaction logic for ProductWindowForCart.xaml
    /// </summary>
    public partial class ProductWindowForCart : Window
    {
        BlApi.IBL? bl = BlApi.Factory.GetBl() ?? throw new NullReferenceException("Missing bl");

        BO.Product productBO = new BO.Product();
        BO.ProductItem productItemBO = new BO.ProductItem();

        BO.Cart? cartBO = new();
        PO.CartPO? cartPO = new();

        public ProductWindowForCart(int id, BO.Cart cart)
        {
            InitializeComponent();
            cartBO = cart;
            cartPO = PL.Tools.BoTOPoCart(cartBO);

            productItemBO = bl.Product.GetProductByIDAndCart(id, cart);
            
            DataContext = productItemBO;
            if (productItemBO.InStock==true)
            {
                InStockOfItemTextBox.Text = "במלאי";
            }
            else
            {
                InStockOfItemTextBox.Text = "לא במלאי";
            }
            

            //categoryComboBox.ItemsSource = Enum.GetValues(typeof(BO.Category));
        }

        private void AddProductToCart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl!.cart.AddProductToCart(cartBO, productItemBO.ID);
                MessageBox.Show("seccssed");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            Close();
        }
    }
}
