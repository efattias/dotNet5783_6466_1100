using BlApi;
using BlImplementation;
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

namespace PL.Cwindows
{
    /// <summary>
    /// Interaction logic for productListWindow.xaml
    /// </summary>
    public partial class productListWindow : Window
    {
        private IBL bl = new Bl();
        public productListWindow()
        {
            InitializeComponent();
            productListView.ItemsSource = bl.Product.getProductForList();
            categorySelector.ItemsSource = Enum.GetValues(typeof(BO.Category));
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
               
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void categorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
