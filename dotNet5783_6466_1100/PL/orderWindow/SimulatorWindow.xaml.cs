using BlApi;
using PL.PO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace PL.orderWindow;

/// <summary>
/// Interaction logic for SimulatorWindow.xaml
/// </summary>
public partial class SimulatorWindow : Window
{
    BlApi.IBL? bl = BlApi.Factory.GetBl() ?? throw new NullReferenceException("Missing bl");
    // private IBL bl = Factory.GetBl();
    ObservableCollection<OrderForListPO> orderListPO = new();
    BackgroundWorker? worker;
    DateTime time = DateTime.Now;
    bool flag=true;
    public SimulatorWindow()
    {
        InitializeComponent();
        worker = new BackgroundWorker();
        worker.DoWork += Worker_DoWork;
        worker.ProgressChanged += Worker_ProgressChanged!;
        worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        worker.WorkerSupportsCancellation = true;
        worker.WorkerReportsProgress = true;



        IEnumerableToObservable(bl.Order.getOrderForList());
        DataContext = orderListPO;
    }
    private void doubleClickShowOrder(object sender, MouseButtonEventArgs e)
    {
        //DataContext = orderListPO;
        // var order = (OrderForListPO)orderListV.SelectedItem;
        new orderTrackSimulator((PO.OrderForListPO)orderListV.SelectedItem).ShowDialog();
        // new orderWindow((PO.OrderForListPO)orderListV.SelectedItem
        // DataContext = orderListPO;
        //  IEnumerableToObservable(bl.Order.getOrderForList());
    }
    private void IEnumerableToObservable(IEnumerable<BO.OrderForList> listTOConvert)
    {
        var listPO = (from o in listTOConvert
                      select new PO.OrderForListPO
                      {
                          ID = o.ID,
                          CustomerName = o.CustomerName,
                          OrderStatus = (PO.Status)o.OrderStatus!,
                          AmountOfItems = o.AmountOfItems,
                          TotalPrice = o.TotalPrice


                      }).ToList();
        orderListPO.Clear();
        foreach (var o in listPO)
            orderListPO.Add(o);

    }

    private void Worker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Cancelled == true)
            MessageBox.Show("סימולטור בהפסקה");
        else if (flag == false)
        {
            stop.IsEnabled= false;
            play.IsEnabled = true;
            MessageBox.Show("סימולטור סיים");
        }



    
    }

    private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {// לבדוק אם 0\1
        IEnumerableToObservable(bl!.Order.getOrderForList());
         flag = false;
        foreach (PO.OrderForListPO order in orderListPO)
        {
        
            //DateTime currentTime = DateTime.Now; 
            //if (order.OrderStatus is not Status.נשלח && time > currentTime.AddDays(4))
            //{
            //    order.OrderStatus = Status.נשלח; break;

            //}
            //if (order.OrderStatus is not Status.נמסר && time > currentTime.AddDays(3))
            //{
            //    order.OrderStatus = Status.נמסר; break;

            //}
            if (order.OrderStatus == PO.Status.מאושר)
            {
                flag = true;
                DateTime orderDateTime = (DateTime)bl!.Order.GetOrder((int)order!.ID!).OrderDate!;
                orderDateTime = orderDateTime.AddDays(3);
                if (orderDateTime <= time)
                {
                    order.OrderStatus = PO.Status.נשלח;
                    bl.Order.UpdateShipOrder((int)order.ID);
                    break;
                }
            }
            else if (order.OrderStatus == PO.Status.נשלח)
            {
                flag = true;
                // BO.Order o = bl.Order.GetOrder((int)order.ID);
                DateTime orderDateTime = (DateTime)bl!.Order.GetOrder((int)order!.ID!).ShipDate!;
                orderDateTime = orderDateTime.AddDays(4);
                if (orderDateTime <= time)
                {
                    order.OrderStatus = PO.Status.נמסר;
                    bl.Order.UpdateProvisionOrder((int)order.ID);
                    break;
                }
            }
            
        }
    }

    private void Worker_DoWork(object? sender, DoWorkEventArgs e)
    {
        while (flag)
        {
            if (worker?.CancellationPending == true)
            {
                e.Cancel = true;
                break;
            }
            else
            {
                if (worker!.WorkerReportsProgress! == true)
                {
                    time = time.AddHours(20);
                    Thread.Sleep(2000);
                    worker.ReportProgress(4);
                }
            }
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

        worker!.RunWorkerAsync();
        play.IsEnabled = false;
        stop.IsEnabled = true;
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        worker!.CancelAsync();
        stop.IsEnabled = false;
        play.IsEnabled = true;
    }
}
