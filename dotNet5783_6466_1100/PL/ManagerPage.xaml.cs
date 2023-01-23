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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PL
{
    /// <summary>
    /// Interaction logic for ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        DispatcherTimer timer;
        readonly double panelWidth;
        private bool hidden = true;
        Frame f;

        public ManagerPage(Frame mainFrame)
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;
            f = mainFrame;
            panelWidth = sidePanel.Width;
            sidePanel.Width = 60;
            ListFrame.Content = new ManagerPageWindow();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {
                sidePanel.Width += 5;
                if (sidePanel.Width >= panelWidth)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                sidePanel.Width -= 5;
                if (sidePanel.Width <= 60)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) => timer.Start();

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
                case 2:
                    {
                        SimulatorWindow window=new SimulatorWindow();
                        window.Show();
                        break;
                    }
            

                    case 3:
                    {
                        f.Content = new MainPage(f);
                        break;
                    }
            
             
                default:
                    break;
            }
        }

        private void SidePanel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sidePanel.Width > 60)
            {
                ToggleButton.IsChecked = false;
                hidden = false;
                timer.Start();
            }
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
