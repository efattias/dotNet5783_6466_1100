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
        //PO.ProductItemPO product= new PO.ProductItemPO();
        public ProductWindowForCart(int idPO)
        {
            InitializeComponent();
            categoryComboBox.ItemsSource = Enum.GetValues(typeof(BO.Category));
            productBO = bl.Product.GetProductbyId(idPO);
            AmountOfItemTextBox.Text = productBO!.InStock!.ToString();
            //PL.Tools.CopyPropTo(productBO, product);
            DataContext = productBO;
        }
    }
}
