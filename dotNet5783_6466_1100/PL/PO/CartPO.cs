using BO;
using DO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.PO
{
    class CartPO
    {
        private string? name;
        public string? Name 
        {
            get
            { return name; }
            set
            {
                name = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }
        private string? email;
        public string? Email
        {
            get
            { return email; }
            set
            {
                email = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Email"));
                }
            }
        }
        private string? address;
        public string? Address
        {
            get
            { return address; }
            set
            {
                address = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Address"));
                }
            }
        }
        private List<BO.OrderItem>? orderItemList;
        public List<BO.OrderItem>? OrderItemList
        {
            get
            { return orderItemList; }
            set
            {
                orderItemList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("OrderItemList"));
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
