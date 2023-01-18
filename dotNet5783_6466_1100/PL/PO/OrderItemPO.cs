﻿//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PL.PO
//{
//  public  class OrderItemPO:INotifyPropertyChanged
//    {
//        public event PropertyChangedEventHandler? PropertyChanged;

//        private int id;
//        public int ID
//        {
//            get
//            { return id; }
//            set
//            {
//                id = value;
//                if (PropertyChanged != null)
//                {
//                    PropertyChanged(this, new PropertyChangedEventArgs("ID"));
//                }
//            }
//        }

//        private int productID;
//        public int ProductID
//        {
//            get
//            { return productID; }
//            set
//            {
//                productID = value;
//                if (PropertyChanged != null)
//                {
//                    PropertyChanged(this, new PropertyChangedEventArgs("ProductID"));
//                }
//            }
//        }


//        private string? name;
//        public string Name
//        {
//            get
//            { return name ?? throw new ArgumentNullException("no name"); }
//            set
//            {
//                name = value;
//                if (PropertyChanged != null)
//                {
//                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
//                }
//            }
//        }

//        private double price;
//        public double Price
//        {
//            get
//            { return price; }
//            set
//            {
//                price = value;
//                if (PropertyChanged != null)
//                {
//                    PropertyChanged(this, new PropertyChangedEventArgs("Price"));
//                }
//            }
//        }

//        private double amount;
//        public double Amount
//        {
//            get
//            { return amount; }
//            set
//            {
//                amount = value;
//                if (PropertyChanged != null)
//                {
//                    PropertyChanged(this, new PropertyChangedEventArgs("Amount"));
//                }
//            }
//        }

//        private double totalPrice;
//        public double TotalPrice
//        {
//            get
//            { return totalPrice; }
//            set
//            {
//                totalPrice = value;
//                if (PropertyChanged != null)
//                {
//                    PropertyChanged(this, new PropertyChangedEventArgs("TotalPrice"));
//                }
//            }
//        }



//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
//using System.Collections.Generic;
using System.ComponentModel;

namespace PL.PO;

public class OrderItemPO : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

   


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

    private int? productID;
    public int? ProductID
    {
        get
        { return productID; }
        set
        {
            productID = value;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("ProductID"));
            }
        }
    }

    private double? price;
    public double? Price
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

    private int? amount;
    public int? Amount
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



    private string? path;

    public string? Path
    {
        get
        { return path; }
        set
        {
            path = value;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Path"));
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


}

