using PL.orderWindow;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();
            ListFrame.Content = new ManagerPageWindow();
        }
        private void OpenLists_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            switch (((ListView)sender).SelectedIndex)
            {
                case 0:
                    {
                        ListFrame.Content = new orderListPage();
                        break;
                    }
                case 1:
                    {
                        ListFrame.Content = new ProductListPage();
                        break;
                    }
                default:
                    break;
            }
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

    }
}
