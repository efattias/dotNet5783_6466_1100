using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Ribbon.Primitives;

namespace PL.PO
{
   public class OrderForListPO:INotifyPropertyChanged
    {
        private int? id;
        public int? ID
        {
            get
            { return id; }
            set
            {
                id = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ID"));
                }
            }
        }
        private string? customerName;
        public string? CustomerName
        {
            get
            { return customerName; }
            set
            {
                customerName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CustomerName"));
                }
            }
        }

       
       


        private Status? orderStatus;
        public Status? OrderStatus
        {
            get
            { return orderStatus; }
            set
            {
                orderStatus = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("OrderStatus"));
                }
            }
        }

        private int? amountOfItems;
        public int? AmountOfItems
        {
            get
            { return amountOfItems; }
            set
            {
                amountOfItems = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AmountOfItems"));
                }
            }
        }
        private double? totalPrice;
        public double? TotalPrice
        {
            get
            { return totalPrice; }
            set
            {
                totalPrice = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("TotalPrice"));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
