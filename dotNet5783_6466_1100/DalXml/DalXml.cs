using DalApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using DO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;

public struct ImportentNumbers
{
    public double numberSaved { get; set; }
    public string typeOfnumber { get; set; }
}

sealed class DalXml : IDal
{
    public static IDal Instance { get; } = new DalXml();
    private DalXml() { }
    public IOrder Order { get; }= new Dal.order();
    public IProduct Product { get; }= new Dal.product();
    public IOrderItem OrderItem { get; }=new Dal.orderItem();
}

