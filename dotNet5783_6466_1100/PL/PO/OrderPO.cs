using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.PO
{
    public class OrderPO
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

        private string? customerEmail;
        public string? CustomerEmail
        {
            get
            { return customerEmail; }
            set
            {
                customerEmail = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CustomerEmail"));
                }
            }
        }

        private string? customerAddress;
        public string? CustomerAddress
        {
            get
            { return customerAddress; }
            set
            {
                customerAddress = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CustomerAddress"));
                }
            }
        }


        private DateTime orderDate;
        public DateTime OrderDate
        {
            get
            { return orderDate; }
            set
            {
                orderDate = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("OrderDate"));
                }
            }
        }

        private DateTime shipDate;
        public DateTime ShipDate
        {
            get
            { return shipDate; }
            set
            {
                shipDate = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ShipDate"));
                }
            }
        }

        private DateTime deliveryDate;
        public DateTime DeliveryDate
        {
            get
            { return deliveryDate; }
            set
            {
                deliveryDate = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DeliveryDate"));
                }
            }
        }
        private List<OrderItemPO>? items;
        public List<OrderItemPO>? Items
        {
            get
            { return items; }
            set
            {
                items = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Items"));
                }
            }
        }

        private double totalPrice;
        public double TotalPrice
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
