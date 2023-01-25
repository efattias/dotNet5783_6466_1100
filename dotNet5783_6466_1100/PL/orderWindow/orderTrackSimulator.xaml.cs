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
    /// Interaction logic for orderTrackSimulator.xaml
    /// </summary>
    public partial class orderTrackSimulator : Window
    {
        BlApi.IBL? bl = BlApi.Factory.GetBl() ?? throw new NullReferenceException("Missing bl");
        BO.OrderTracking oTrack = new BO.OrderTracking();
        
        public orderTrackSimulator(PO.OrderForListPO? order = null)
        {
            
            InitializeComponent();


            if (order != null)
            {
                oTrack = bl.Order.TrackOrder((int)order!.ID!);
                DataContext = oTrack;

                //  StatusTextBox.Text = oTrack!.OrderStatus.ToString();
                string s = "";
                foreach (var o in oTrack.trackList!)
                    s += (o.ToString()) + "\n";
                ListTextBox.Text = s;
            }
        }
    }
}



       

