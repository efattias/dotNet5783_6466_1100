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
using BO;
using PL.productWindow;
using System.Collections.ObjectModel;

namespace PL
{
    /// <summary>
    /// Interaction logic for OrderTrackingPage.xaml
    /// </summary>
    public partial class OrderTrackingPage : Page
    {
        BlApi.IBL? bl = BlApi.Factory.GetBl() ?? throw new NullReferenceException("Missing bl");
        BO.OrderTracking oTrack=new BO.OrderTracking();
        public OrderTrackingPage()
        {

            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BO.Order order = bl.Order.GetOrder(int.Parse(IDTextBox.Text));

                oTrack = bl.Order.TrackOrder(order.ID);
                DataContext = oTrack;

                //  StatusTextBox.Text = oTrack!.OrderStatus.ToString();
                string s = "";
                foreach (var o in oTrack.trackList!)
                    s += (o.ToString()) + "\n";
                ListTextBox.Text = s;
            }
            catch(BO.DoesntExistException x)         
                  
            {
                MessageBox.Show(x.Message);
            }
        }
            //ListTextBox.Text=oTrack.trackList!.ToString();
            //List<Tuple<DateTime?, string>>? trackList = oTrack.trackList;
            //trackListBox = trackList.ToList();
        }
    }
