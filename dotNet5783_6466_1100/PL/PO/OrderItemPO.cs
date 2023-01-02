using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.PO
{
    class OrderItemPO
    {

        private int id;
        public int ID
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

        private int idProduct;
        public int IDProduct
        {
            get
            { return idProduct; }
            set
            {
                idProduct = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IDProduct"));
                }
            }
        }


        private string? name;
        public string Name
        {
            get
            { return name ?? throw new ArgumentNullException("no name"); }
            set
            {
                name = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        private double price;
        public double Price
        {
            get
            { return price; }
            set
            {
                price = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Price"));
                }
            }
        }

        private double amount;
        public double Amount
        {
            get
            { return amount; }
            set
            {
                amount = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Amount"));
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
