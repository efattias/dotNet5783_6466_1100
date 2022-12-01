using DO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;
public class OrderForList
{
    public int ID { get; set; }
    public string? CustomerName { get; set; }
    public Status? OrderStatus { get; set; }
    public int? AmountOfItems { get; set; }
    public double? TotalPrice { get; set; }

    public override string ToString() => $@"
        ID={ID}
        Customer name={CustomerName}
        Order status={OrderStatus}
        Amount of items: {AmountOfItems}
    	Total price: {TotalPrice}
";

}

