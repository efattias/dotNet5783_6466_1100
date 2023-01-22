using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.PO
{
   public class ProductPO:INotifyPropertyChanged
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

            private Category category;
            public Category Category
            {
                get
                { return category; }
                set
                {
                    category = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Category"));
                    }
                }
            }

            private int inStock;
            public int InStock
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
        private string? path;
        public string Path
        {
            get
            { return path!; }
            set
            {
                path = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Path"));
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        
    }
}

