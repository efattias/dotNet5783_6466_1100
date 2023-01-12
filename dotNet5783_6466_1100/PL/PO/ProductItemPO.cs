using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.PO
{
    internal class ProductItemPO
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
        private Category categoty;
        public Category Category
        {
            get
            { return categoty; }
            set
            {
                categoty = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Category"));
                }
            }
        }
        private bool inStock;
        public bool InStock
        {
            get
            { return inStock; }
            set
            {
                inStock = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("InStock"));
                }
            }
        }
        private int amount;
        public int Amount
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

        public event PropertyChangedEventHandler? PropertyChanged;
    }
    
}
