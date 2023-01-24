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
        PO.ProductItemPO productItemPO=new ProductItemPO();

        BO.Cart? cartBO = new();
        PO.CartPO? cartPO = new();

        public ProductWindowForCart(int id, BO.Cart cart)
        {
            InitializeComponent();

            cartBO = cart;
            cartPO = PL.Tools.BoTOPoCart(cartBO);

            productItemBO = bl.Product.GetProductByIDAndCart(id, cart);
            productItemPO = Tools.CopyPropTo(productItemBO, productItemPO);
            
            DataContext = productItemPO;

            if (productItemBO.InStock == true)
                InStockOfItemTextBox.Text = "במלאי";
            else
                InStockOfItemTextBox.Text = "לא במלאי";
        }

        private void AddProductToCart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl!.cart.AddProductToCart(cartBO, productItemBO.ID);
                productItemPO.Amount += 1;
               // Close();
                MessageBox.Show("נוסף לסל");
            }
            catch (Exception x)
            {
                Close();
                MessageBox.Show(x.Message);
            }
            
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (productItemBO.Amount == 0)
                    MessageBox.Show("אינו קיים בסל");
                else
                {

                    MessageBoxResult messageBoxResult = MessageBox.Show("?האם למחוק את המוצר מהסל", "מחיקת מוצר", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if  (messageBoxResult is (MessageBoxResult.Yes))
                    {
                        bl!.cart!.UpdateProductInCart(cartBO, productItemBO.ID, 0);
                        Close();
                        MessageBox.Show("נמחק מהסל");
                    
                    }
                  
                }
            }
            catch (Exception x)
            {
                Close();
                MessageBox.Show(x.Message);
            }
        }
    }
}
